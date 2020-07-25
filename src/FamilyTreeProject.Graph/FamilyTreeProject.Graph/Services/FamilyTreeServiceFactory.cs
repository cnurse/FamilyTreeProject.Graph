using FamilyTreeProject.Graph.Contracts;
using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Services.Interfaces;
using FamilyTreeProject.Graph.Vertices;
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
        private IHasService<Note> _hasNoteService;
        //private IHasService<Source> _hasSourceService;
        private IIndividualService _individualService;
        private INoteService _noteService;
        private IParentService _parentService;
        private IReferencedInService _referencedInService;
        private IRepositoryService _repositoryService;
        private ISourceService _sourceService;
        private ISpouseService _spouseService;
        /*private ITreeContainsService<Individual> _treeContainsIndividualService;
        private ITreeContainsService<Repository> _treeContainsRepositoryService;
        private ITreeContainsService<Source> _treeContainsSourceService;*/
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
        /// <param name="tree">The family tree we are working with</param>
        /// <returns>An ICitationService</returns>
        public ICitationService CreateCitationService(Tree tree)
        {
            return _citationService ??= new CitationService(_unitOfWork, this, tree);
        }

        /// <summary>
        /// Creates a Fact service
        /// </summary>
        /// <param name="tree">The family tree we are working with</param>
        /// <returns>An IFactService</returns>
        public IFactService CreateFactService(Tree tree)
        {
            return _factService ??= new FactService(_unitOfWork, this, tree);
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
        /// Create a Has<Note> service
        /// </summary>
        /// <returns>An IHasService<Note></returns>
        public IHasService<Note> CreateHasNoteService()
        {
            return _hasNoteService ??= new HasService<Note>(_unitOfWork);
        }

        /*
        /// <summary>
        /// Create a Has<Source> service
        /// </summary>
        /// <returns>An IHasService<Note></returns>
        public IHasService<Source> CreateHasSourceService()
        {
            return _hasSourceService ??= new HasService<Source>(_unitOfWork);
        }
        */

        /// <summary>
        /// Create an Individual service
        /// </summary>
        /// <param name="tree">The family tree we are working with</param>
        /// <returns>An IIndividualService</returns>
        public IIndividualService CreateIndividualService(Tree tree)
        {
            return _individualService ??= new IndividualService(_unitOfWork, this, tree);
        }

        /// <summary>
        /// Create a Note service
        /// </summary>
        /// <param name="tree">The family tree we are working with</param>
        /// <returns>A Note Service</returns>
        public INoteService CreateNoteService(Tree tree)
        {
            return _noteService ??= new NoteService(_unitOfWork, this, tree);
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
        /// <param name="tree">The family tree we are working with</param>
        /// <returns>An IRepositoryService</returns>
        public IRepositoryService CreateRepositoryService(Tree tree)
        {
            return _repositoryService ??= new RepositoryService(_unitOfWork, this, tree);
        }

        /// <summary>
        /// Creates a SourceService
        /// </summary>
        /// <param name="tree">The family tree we are working with</param>
        /// <returns>An ISourceService</returns>
        public ISourceService CreateSourceService(Tree tree)
        {
            return _sourceService ??= new SourceService(_unitOfWork, this, tree);
        }

        /// <summary>
        /// Create a Spouse service
        /// </summary>
        /// <returns>A Spouse Service</returns>
        public ISpouseService CreateSpouseService()
        {
            return _spouseService ??= new SpouseService(_unitOfWork);
        }

        /*
        /// <summary>
        /// Create a TreeContainsIndividualService service
        /// </summary>
        /// <param name="tree">The family tree we are working with</param>
        /// <returns>A TreeContainsIndividualService Service</returns>
        public ITreeContainsService<Individual> CreateTreeContainsIndividualService()
        {
            return _treeContainsIndividualService ??= new TreeContainsService<Individual>(_unitOfWork);
        }

        /// <summary>
        /// Create a TreeContainsRepositoryService service
        /// </summary>
        /// <param name="tree">The family tree we are working with</param>
        /// <returns>A TreeContainsRepositoryService Service</returns>
        public ITreeContainsService<Repository> CreateTreeContainsRepositoryService()
        {
            return _treeContainsRepositoryService ??= new TreeContainsService<Repository>(_unitOfWork);
        }

        /// <summary>
        /// Create a TreeContainsSourceService service
        /// </summary>
        /// <param name="tree">The family tree we are working with</param>
        /// <returns>A TreeContainsSourceService Service</returns>
        public ITreeContainsService<Source> CreateTreeContainsSourceService()
        {
            return _treeContainsSourceService ??= new TreeContainsService<Source>(_unitOfWork);
        }
        */
        
        /// <summary>
        /// Creates a TreeService
        /// </summary>
        /// <param name="tree">The family tree we are working with</param>
        /// <returns>Am ITreeService</returns>
        public ITreeService CreateTreeService()
        {
            return _treeService ??= new TreeService(_unitOfWork);
        }
    }
}