using FamilyTreeProject.Graph.Contracts;
using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Services.Interfaces;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// The SourceService contains methods to manage source objects
    /// </summary>
    public class SourceService : FamilyTreeVertexServiceBase<Source>, ISourceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFoundInService _foundInService;
        // private readonly IHasService<Source> _hasSourceService;

        /// <summary>
        /// Constructs a SourceService
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        /// <param name="serviceFactory">The service factory to use to create services</param>
        /// <param name="tree">The tree we are working with</param>
        public SourceService(IUnitOfWork unitOfWork, IFamilyTreeServiceFactory serviceFactory, Tree tree) : base(unitOfWork, serviceFactory, tree)
        {
            Requires.NotNull(unitOfWork);

            _unitOfWork = unitOfWork;
            _foundInService = serviceFactory.CreateFoundInService();
            // _hasSourceService = serviceFactory.CreateHasSourceService();
        }

        /// <summary>
        /// Adds a Source the data store
        /// </summary>
        /// <param name="source">The source to add</param>
        /// <param name="addEdges">A flag that determines whether the edges are added</param>
        public void Add(Source source, bool addEdges)
        {
            AddInternal(source, addEdges);
            if (addEdges)
            {
                var foundIn = source.Repository;
                if (foundIn != null)
                {
                    var repository = foundIn.TargetVertex;
                    
                    //Add Repository Edges
                    _foundInService.Add(foundIn);
                    // _hasSourceService.Add(new Has<Source>(repository, source));
                }
            }
            _unitOfWork.Commit();
        }
    }
}