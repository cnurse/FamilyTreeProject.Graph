using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Edges;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// The SourceService contains methods to manage source objects
    /// </summary>
    public class SourceService : FamilyTreeVertexService<Source>, ISourceService
    {
        private readonly IEdgeRepository<FamilyTreeVertexBase, Tree> _belongsToTreeRepository;
        private readonly IEdgeRepository<Source, Repository> _foundInRepository;
        private readonly IEdgeRepository<FamilyTreeVertexBase, Source> _hasSourceRepository;
        private readonly IEdgeRepository<Tree, Source> _treeContainsRepository;

        /// <summary>
        /// Constructs a SourceService
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        public SourceService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _belongsToTreeRepository = unitOfWork.GetEdgeRepository<FamilyTreeVertexBase, Tree>();
            _treeContainsRepository = unitOfWork.GetEdgeRepository<Tree, Source>();
            _foundInRepository = unitOfWork.GetEdgeRepository<Source, Repository>();
            _hasSourceRepository = unitOfWork.GetEdgeRepository<FamilyTreeVertexBase, Source>();
        }

        /// <summary>
        /// AddEdges is used to add the edges when the base classes Add method is called with addEdges = true
        /// </summary>
        /// <param name="source">The source being added</param>
        /// <param name="tree">The tree that the source belongs to</param>
        protected override void AddEdges(Source source, Tree tree)
        {
            if (source.Repository != null)
            {
                var repository = source.Repository.TargetVertex;

                //Add Repository Edges
                _foundInRepository.Add(new Found_In(source, repository));
                _hasSourceRepository.Add(new Has<Source>(repository, source));
            }
            
            //Add Tree edges
            _belongsToTreeRepository.Add(new BelongsToTree(source, tree));
            _treeContainsRepository.Add(new TreeContains<Source>(tree, source));
        }
    }
}