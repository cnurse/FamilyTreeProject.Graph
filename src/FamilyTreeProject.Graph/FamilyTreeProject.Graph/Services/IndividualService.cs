using FamilyTreeProject.Graph.Contracts;
using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Services.Interfaces;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// The IndividualService contains methods to manage individual objects
    /// </summary>
    public class IndividualService : CitationsVertexServiceBase<Individual>, IIndividualService
    {        
        private readonly IUnitOfWork _unitOfWork;

        private readonly IFactService _factService;
        private readonly IHasService<Fact> _hasFactService;
        
        /// <summary>
        /// Constructs an IndividualService
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        /// <param name="serviceFactory">The service factory to use to create services</param>
        /// <param name="tree">The tree we are working with</param>
        public IndividualService(IUnitOfWork unitOfWork, IFamilyTreeServiceFactory serviceFactory, Tree tree) : base(unitOfWork, serviceFactory, tree)
        {
            Requires.NotNull(unitOfWork);
            _factService = serviceFactory.CreateFactService(tree);
            _hasFactService = serviceFactory.CreateHasFactService();
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Adds an Individual to the data store
        /// </summary>
        /// <param name="individual">The individual to add</param>
        /// <param name="addEdges">A flag that determines whether the edges are added</param>
        public void Add(Individual individual, bool addEdges)
        {
            AddInternal(individual, addEdges);
            if (addEdges)
            {
                foreach (var hasFact in individual.Facts)
                {
                    var fact = (Fact)hasFact.TargetVertex;

                    _factService.Add(fact, addEdges);
                    _hasFactService.Add(hasFact);
                }
            }

            _unitOfWork.Commit();
        }
    }
}