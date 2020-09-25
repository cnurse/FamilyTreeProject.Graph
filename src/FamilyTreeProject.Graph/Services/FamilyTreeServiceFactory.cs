using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Services.Interfaces;
using FamilyTreeProject.Graph.Vertices;
using Microsoft.Extensions.Caching.Memory;
using Naif.Core.Contracts;

// ReSharper disable InvalidXmlDocComment

namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// Implements a Factory to create Family Tree services
    /// </summary>
    public class FamilyTreeServiceFactory : IFamilyTreeServiceFactory
    {
        private IBelongsToTreeService _belongsToTreeService;
        private IChildService _childService;
        private ICitationService _citationService;
        private IFactService _factService;
        private IFoundInService _foundInService;
        private IHasService<Citation> _hasCitationService;
        private IHasService<Fact> _hasFactService;
        private IHasHomeIndividualService _hasHomeIndividualService;
        private IHasService<Note> _hasNoteService;
        private IIndividualService _individualService;
        private INoteService _noteService;
        private IParentService _parentService;
        private IReferencedInService _referencedInService;
        private IRepositoryService _repositoryService;
        private ISourceService _sourceService;
        private ISpouseService _spouseService;
        private ITreeService _treeService;
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _memoryCache;
        
        /// <summary>
        /// Constructs a FamilyTreeServiceFactory
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        public FamilyTreeServiceFactory(IMemoryCache memoryCache, IUnitOfWork unitOfWork)
        {
            Requires.NotNull(memoryCache);
            Requires.NotNull(unitOfWork);

            _memoryCache = memoryCache;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Create a BelongsToTree service
        /// </summary>
        /// <param name="tree">The family tree we are working with</param>
        /// <returns>A BelongsToTree Service</returns>
        public IBelongsToTreeService CreateBelongsToTreeService()
        {
            return _belongsToTreeService ??= new BelongsToTreeService(_unitOfWork);
        }

        /// <summary>
        /// Create a Child service
        /// </summary>
        /// <returns>A Child Service</returns>
        public IChildService CreateChildService()
        {
            return _childService ??= new ChildService(_unitOfWork);
        }

        /// <summary>
        /// Creates a Citation service
        /// </summary>
        /// <returns>An ICitationService</returns>
        public ICitationService CreateCitationService()
        {
            return _citationService ??= new CitationService(_unitOfWork, this);
        }

        /// <summary>
        /// Creates a Fact service
        /// </summary>
        /// <returns>An IFactService</returns>
        public IFactService CreateFactService()
        {
            return _factService ??= new FactService(_unitOfWork, this);
        }
        
        /// <summary>
        /// Create a FoundIn service
        /// </summary>
        /// <returns>An IFoundInService</returns>
        public IFoundInService CreateFoundInService()
        {
            return _foundInService ??= new FoundInService(_unitOfWork);
        }

        /// <summary>
        /// Create a Has<Citation> service
        /// </summary>
        /// <returns>An IHasService<Citation></returns>
        public IHasService<Citation> CreateHasCitationService()
        {
            return _hasCitationService ??= new HasService<Citation>(_unitOfWork);
        }

        /// <summary>
        /// Create a Has<Fact> service
        /// </summary>
        /// <returns>An IHasService<Fact></returns>
        public IHasService<Fact> CreateHasFactService()
        {
            return _hasFactService ??= new HasService<Fact>(_unitOfWork);
        }

        /// <summary>
        /// Create a HasHomeIndividual service
        /// </summary>
        /// <returns>A HasHomeIndividual Service</returns>
        public IHasHomeIndividualService CreateHasHomeIndividualService()
        {
            return _hasHomeIndividualService ??= new HasHomeIndividualService(_unitOfWork);
        }

        /// <summary>
        /// Create a Has<Note> service
        /// </summary>
        /// <returns>An IHasService<Note></returns>
        public IHasService<Note> CreateHasNoteService()
        {
            return _hasNoteService ??= new HasService<Note>(_unitOfWork);
        }

        /// <summary>
        /// Create an Individual service
        /// </summary>
        /// <returns>An IIndividualService</returns>
        public IIndividualService CreateIndividualService()
        {
            return _individualService ??= new IndividualService(_memoryCache, _unitOfWork, this);
        }

        /// <summary>
        /// Create a Note service
        /// </summary>
        /// <returns>A Note Service</returns>
        public INoteService CreateNoteService()
        {
            return _noteService ??= new NoteService(_unitOfWork, this);
        }

        /// <summary>
        /// Create a Parent service
        /// </summary>
        /// <returns>A Parent Service</returns>
        public IParentService CreateParentService()
        {
            return _parentService ??= new ParentService(_unitOfWork);
        }

        /// <summary>
        /// Create a ReferencedIn service
        /// </summary>
        /// <returns>A ReferencedIn Service</returns>
        public IReferencedInService CreateReferencedInService()
        {
            return _referencedInService ??= new ReferencedInService(_unitOfWork);
        }

        /// <summary>
        /// Creates a RepositoryService
        /// </summary>
        /// <returns>An IRepositoryService</returns>
        public IRepositoryService CreateRepositoryService()
        {
            return _repositoryService ??= new RepositoryService(_unitOfWork, this);
        }

        /// <summary>
        /// Creates a SourceService
        /// </summary>
        /// <returns>An ISourceService</returns>
        public ISourceService CreateSourceService()
        {
            return _sourceService ??= new SourceService(_unitOfWork, this);
        }

        /// <summary>
        /// Create a Spouse service
        /// </summary>
        /// <returns>A Spouse Service</returns>
        public ISpouseService CreateSpouseService()
        {
            return _spouseService ??= new SpouseService(_unitOfWork);
        }

        /// <summary>
        /// Creates a TreeService
        /// </summary>
        /// <param name="tree">The family tree we are working with</param>
        /// <returns>Am ITreeService</returns>
        public ITreeService CreateTreeService()
        {
            return _treeService ??= new TreeService(_unitOfWork, this);
        }
    }
}