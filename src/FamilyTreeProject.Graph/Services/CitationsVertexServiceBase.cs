using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Services.Interfaces;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// An abstract base class for CitationsVertexBase services (Individual, Fact)
    /// </summary>
    /// <typeparam name="V"></typeparam>
    public abstract class CitationsVertexServiceBase<V> : FamilyTreeVertexServiceBase<V> where V: CitationsVertexBase, new()
    {
        private readonly ICitationService _citationService;
        private readonly IHasService<Citation> _hasCitationService;

        /// <summary>
        /// Constructs a CitationsVertexServiceBase
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        /// <param name="serviceFactory">The service factory to use to create services</param>
        /// <param name="tree">The tree we are working with</param>
        protected CitationsVertexServiceBase(IUnitOfWork unitOfWork, IFamilyTreeServiceFactory serviceFactory, Tree tree) : base(unitOfWork, serviceFactory, tree)
        {
            _citationService = serviceFactory.CreateCitationService(tree);
            _hasCitationService = serviceFactory.CreateHasCitationService();
        }

        /// <summary>
        /// Add Family Tree Vertices to the data store
        /// </summary>
        /// <param name="item">The CitationsVertexBase to add</param>
        /// <param name="addEdges">A flag that determines whether Edges are also added</param>
        /// <param name="addTreeEdges">A flag that determines whether Tree Edges are added - defaults to true</param>
        protected override void AddInternal(V item, bool addEdges, bool addTreeEdges = true)
        {
            base.AddInternal(item, addEdges, addTreeEdges);
            
            if (addEdges)
            {
                foreach (var citation in item.Citations)
                {
                    _citationService.Add((Citation)citation.TargetVertex, addEdges);
                    _hasCitationService.Add(citation);
                }
            }
        }
    }
}