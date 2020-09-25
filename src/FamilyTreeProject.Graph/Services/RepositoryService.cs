using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Services.Interfaces;
using FamilyTreeProject.Graph.Vertices;
using Naif.Core.Contracts;

namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// The RepositoryService contains methods to manage repository objects
    /// </summary>
    public class RepositoryService : FamilyTreeVertexServiceBase<Repository>, IRepositoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructs a RepositoryService
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        /// <param name="serviceFactory">The service factory to use to create services</param>
        public RepositoryService(IUnitOfWork unitOfWork, IFamilyTreeServiceFactory serviceFactory) : base(unitOfWork, serviceFactory)
        {
            Requires.NotNull(unitOfWork);

            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Adds a Repository to the data store
        /// </summary>
        /// <param name="repository">The Repository to add</param>
        /// <param name="tree">The tree we are working with</param>
        /// <param name="addEdges">A flag that determines whether the edges are added</param>
        public void Add(Repository repository, Tree tree, bool addEdges)
        {
            AddInternal(repository, tree, addEdges);

            _unitOfWork.Commit();
        }
    }
}