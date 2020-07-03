using FamilyTreeProject.Graph.Contracts;
using FamilyTreeProject.Graph.Data;

namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// Implements a Factory to create Family Tree services
    /// </summary>
    public class FamilyTreeServiceFactory : IFamilyTreeServiceFactory
    {
        private IRepositoryService _repositoryService;
        private ISourceService _sourceService;
        private ITreeService _treeService;
        
        private readonly IUnitOfWork _unitOfWork;
        
        /// <summary>
        /// Constructs a FamilyTreeServiceFactory
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        public FamilyTreeServiceFactory(IUnitOfWork unitOfWork)
        {
            Requires.NotNull(unitOfWork);

            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Creates a SourceService
        /// </summary>
        /// <returns>An ISourceService</returns>
        public ISourceService CreateSourceService()
        {
            return _sourceService ??= new SourceService(_unitOfWork);
        }

        /// <summary>
        /// Creates a RepositoryService
        /// </summary>
        /// <returns>An IRepositoryService</returns>
        public IRepositoryService CreateRepositoryService()
        {
            return _repositoryService ??= new RepositoryService(_unitOfWork);
        }
        
        /// <summary>
        /// Creates a TreeService
        /// </summary>
        /// <returns>Am ITreeService</returns>
        public ITreeService CreateTreeService()
        {
            return _treeService ??= new TreeService(_unitOfWork);
        }
    }
}