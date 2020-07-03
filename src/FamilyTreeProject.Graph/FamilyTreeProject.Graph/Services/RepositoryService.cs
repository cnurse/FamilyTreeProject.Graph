using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Edges;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// The RepositoryService contains methods to manage repository objects
    /// </summary>
    public class RepositoryService : FamilyTreeVertexService<Repository>, IRepositoryService
    {
        private readonly IEdgeRepository<FamilyTreeVertexBase, Tree> _belongsToTreeRepository;
        private readonly IEdgeRepository<Tree, Repository> _treeContainsRepository;

        /// <summary>
        /// Constructs a RepositoryService
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        public RepositoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _belongsToTreeRepository = unitOfWork.GetEdgeRepository<FamilyTreeVertexBase, Tree>();
            _treeContainsRepository = unitOfWork.GetEdgeRepository<Tree, Repository>();
        }
        
        /// <summary>
        /// AddEdges is used to add the edges when the base classes Add method is called with addEdges = true
        /// </summary>
        /// <param name="repository">The repository being added</param>
        /// <param name="tree">The tree that the repository belongs to</param>
        protected override void AddEdges(Repository repository, Tree tree)
        {
            _belongsToTreeRepository.Add(new BelongsToTree(repository, tree));
            _treeContainsRepository.Add(new TreeContains<Repository>(tree, repository));
        }
    }
}