using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Services.Interfaces;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// The CitationService contains methods to manage citation objects
    /// </summary>
    public class CitationService : FamilyTreeVertexServiceBase<Citation>, ICitationService
    {
        private readonly IReferencedInService _referencedInService;
        
        /// <summary>
        /// Constructs a CitationService
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        /// <param name="serviceFactory">The service factory to use to create services</param>
        /// <param name="tree">The tree we are working with</param>
        public CitationService(IUnitOfWork unitOfWork, IFamilyTreeServiceFactory serviceFactory) : base(unitOfWork, serviceFactory)
        {
            _referencedInService = serviceFactory.CreateReferencedInService();
        }

        /// <summary>
        /// Adds a Citation to the data store
        /// </summary>
        /// <param name="citation">The Citation to add</param>
        /// <param name="tree">The tree the citation belongs to to add</param>
        /// <param name="addEdges">A flag that determines whether to add the edges</param>
        public void Add(Citation citation, Tree tree, bool addEdges)
        {
            AddInternal(citation, tree, addEdges, false);
            if (addEdges)
            {
                _referencedInService.Add(citation.Source);
            }
        }
    }
}