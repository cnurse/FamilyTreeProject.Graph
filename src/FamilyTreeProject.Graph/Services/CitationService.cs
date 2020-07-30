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
        public CitationService(IUnitOfWork unitOfWork, IFamilyTreeServiceFactory serviceFactory, Tree tree) : base(unitOfWork, serviceFactory, tree)
        {
            _referencedInService = serviceFactory.CreateReferencedInService();
        }

        /// <summary>
        /// Adds a Citation to the data store
        /// </summary>
        /// <param name="citation">The Citation to add</param>
        public void Add(Citation citation, bool addEdges)
        {
            AddInternal(citation, addEdges, false);
            if (addEdges)
            {
                _referencedInService.Add(citation.Source);
            }
        }
    }
}