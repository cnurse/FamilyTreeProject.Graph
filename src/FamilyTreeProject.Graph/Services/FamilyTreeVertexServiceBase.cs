using System;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Edges;
using FamilyTreeProject.Graph.Services.Interfaces;
using FamilyTreeProject.Graph.Vertices;
using Naif.Core.Contracts;

namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// An abstract base class for FamilyTreeVertex services (Individual, Fact, Citation, Source, Repository)
    /// </summary>
    /// <typeparam name="V"></typeparam>
    public abstract class FamilyTreeVertexServiceBase<V> where V: FamilyTreeVertexBase, new()
    {
        private readonly IVertexRepository<V> _repository;
        private readonly INoteService _noteService;
        private readonly IHasService<Note> _hasNoteService;
        private readonly IBelongsToTreeService _belongsToTreeService;
        
        /// <summary>
        /// Constructs a FamilyTreeVertexServiceBase
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        /// <param name="serviceFactory">The service factory to use to create services</param>
        /// <param name="tree">The tree we are working with</param>
        protected FamilyTreeVertexServiceBase(IUnitOfWork unitOfWork, IFamilyTreeServiceFactory serviceFactory)
        {
            Requires.NotNull(unitOfWork);
            Requires.NotNull(serviceFactory);

            _repository = unitOfWork.GetVertexRepository<V>();
            _noteService = serviceFactory.CreateNoteService();
            _hasNoteService = serviceFactory.CreateHasNoteService();
            _belongsToTreeService = serviceFactory.CreateBelongsToTreeService();
        }

        /// <summary>
        /// Add Family Tree Vertices to the data store
        /// </summary>
        /// <param name="item">The FamilyTreeVertexBase to add</param>
        /// <param name="tree">The tree the FamilyTreeVertexBase belongs to</param>
        /// <param name="addEdges">A flag that determines whether Edges are also added</param>
        /// <param name="addTreeEdges">A flag that determines whether Tree Edges are added - defaults to true</param>
        protected virtual void AddInternal(V item, Tree tree, bool addEdges, bool addTreeEdges = true)
        {
            //Contract
            Requires.NotNull(item);

            if (string.IsNullOrEmpty(item.Id))
            {
                item.Id = Guid.NewGuid().ToString();
            }

            if (string.IsNullOrEmpty(item.TreeId))
            {
                item.TreeId = tree.Id;
            }
            
            _repository.Add(item);

            if (addEdges)
            {
                foreach (var note in item.Notes)
                {
                    _noteService.Add((Note)note.TargetVertex, tree);
                    _hasNoteService.Add(note);
                }

                if (addTreeEdges)
                {
                    AddTreeEdges(item, tree);
                }
            }
        }

        private void AddTreeEdges(V item, Tree tree)
        {
            _belongsToTreeService.Add(new BelongsToTree(item, tree));
        }
    }
}