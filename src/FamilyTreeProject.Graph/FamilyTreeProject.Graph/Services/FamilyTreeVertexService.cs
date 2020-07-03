using System;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Contracts;
using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// An abstract base class for FamilyTreeVertex services (Individual, Source, Repository)
    /// </summary>
    /// <typeparam name="V"></typeparam>
    public abstract class FamilyTreeVertexService<V> : IFamilyTreeVertexService<V> where V : FamilyTreeVertexBase
    {
        private readonly IVertexRepository<V> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVertexRepository<Note> _noteRepository;
        private readonly IEdgeRepository<FamilyTreeVertexBase, Note> _hasNoteRepository;

        /// <summary>
        /// Constructs a FamilyTreeVertexService
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        protected FamilyTreeVertexService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetVertexRepository<V>();
            _noteRepository = _unitOfWork.GetVertexRepository<Note>();
            _hasNoteRepository = _unitOfWork.GetEdgeRepository<FamilyTreeVertexBase, Note>();
        }

        /// <summary>
        /// Add Family Tree Vertices to the data store
        /// </summary>
        /// <param name="repository">The FamilyTreeVertexBase to add</param>
        /// <param name="tree">The Tree to which the FamilyTreeVertexBase belongs</param>
        /// <param name="addEdges">A flag that determines whether Edges are also added</param>
        public void Add(V item, Tree tree, bool addEdges)
        {
            //Contract
            Requires.NotNull(item);

            if (string.IsNullOrEmpty(item.Id))
            {
                item.Id = Guid.NewGuid().ToString();
            }
            
            _repository.Add(item);

            if (addEdges)
            {
                AddEdges(item, tree);
                foreach (var note in item.Notes)
                {
                    Note noteVertex = note.TargetVertex;
                    if (string.IsNullOrEmpty(noteVertex.Id))
                    {
                        noteVertex.Id = Guid.NewGuid().ToString();
                    }
                    _noteRepository.Add(note.TargetVertex);
                    _hasNoteRepository.Add(note);
                }
            }
            _unitOfWork.Commit();

        }

        protected abstract void AddEdges(V item, Tree tree);
    }
}