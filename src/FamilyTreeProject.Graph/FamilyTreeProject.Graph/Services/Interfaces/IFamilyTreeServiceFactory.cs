using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Services.Interfaces
{
    /// <summary>
    /// Defines the methods to create Family Tree Service classes
    /// </summary>
    public interface IFamilyTreeServiceFactory
    {
        /// <summary>
        /// Create a BelongsToTree service
        /// </summary>
        /// <returns>A BelongsToTree Service</returns>
        IBelongsToTreeService CreateBelongsToTreeService();

        /// <summary>
        /// Create a Child service
        /// </summary>
        /// <returns>A Child Service</returns>
        IChildService CreateChildService();

        /// <summary>
        /// Create a Citation service
        /// </summary>
        /// <param name="tree">The family tree we are working with</param>
        /// <returns>A Citation Service</returns>
        ICitationService CreateCitationService(Tree tree);

        /// <summary>
        /// Create a Fact service
        /// </summary>
        /// <param name="tree">The family tree we are working with</param>
        /// <returns>A Fact Service</returns>
        IFactService CreateFactService(Tree tree);

        /// <summary>
        /// Create a FoundIn service
        /// </summary>
        /// <returns>A FoundIn Service</returns>
        IFoundInService CreateFoundInService();

        /// <summary>
        /// Create a HasCitationService service
        /// </summary>
        /// <returns>A HasCitationService Service</returns>
        IHasService<Citation> CreateHasCitationService();

        /// <summary>
        /// Create a HasFactService service
        /// </summary>
        /// <returns>A HasFactService Service</returns>
        IHasService<Fact> CreateHasFactService();

        /// <summary>
        /// Create a HasNoteService service
        /// </summary>
        /// <returns>A HasNoteService Service</returns>
        IHasService<Note> CreateHasNoteService();

        /*/// <summary>
        /// Create a HasSourceService service
        /// </summary>
        /// <returns>A HasSourceService Service</returns>
        IHasService<Source> CreateHasSourceService();*/

        /// <summary>
        /// Create an Individual service
        /// </summary>
        /// <param name="tree">The family tree we are working with</param>
        /// <returns>An Individual Service</returns>
        IIndividualService CreateIndividualService(Tree tree);

        /// <summary>
        /// Create a Note service
        /// </summary>
        /// <param name="tree">The family tree we are working with</param>
        /// <returns>A Note Service</returns>
        INoteService CreateNoteService(Tree tree);

        /// <summary>
        /// Create a Parent service
        /// </summary>
        /// <returns>A Parent Service</returns>
        IParentService CreateParentService();

        /// <summary>
        /// Create a ReferencedIn service
        /// </summary>
        /// <returns>A ReferencedIn Service</returns>
        IReferencedInService CreateReferencedInService();

        /// <summary>
        /// Create a Repository service
        /// </summary>
        /// <param name="tree">The family tree we are working with</param>
        /// <returns>A Repository Service</returns>
        IRepositoryService CreateRepositoryService(Tree tree);
        
        /// <summary>
        /// Create a Source service
        /// </summary>
        /// <param name="tree">The family tree we are working with</param>
        /// <returns>A Source Service</returns>
        ISourceService CreateSourceService(Tree tree);
        
        /// <summary>
        /// Create a Spouse service
        /// </summary>
        /// <returns>A Spouse Service</returns>
        ISpouseService CreateSpouseService();

        /*
        /// <summary>
        /// Create a TreeContainsIndividualService service
        /// </summary>
        /// <param name="tree">The family tree we are working with</param>
        /// <returns>A TreeContainsIndividualService Service</returns>
        ITreeContainsService<Individual> CreateTreeContainsIndividualService();

        /// <summary>
        /// Create a TreeContainsRepositoryService service
        /// </summary>
        /// <param name="tree">The family tree we are working with</param>
        /// <returns>A TreeContainsRepositoryService Service</returns>
        ITreeContainsService<Repository> CreateTreeContainsRepositoryService();

        /// <summary>
        /// Create a TreeContainsSourceService service
        /// </summary>
        /// <param name="tree">The family tree we are working with</param>
        /// <returns>A TreeContainsSourceService Service</returns>
        ITreeContainsService<Source> CreateTreeContainsSourceService();
        */
        
        /// <summary>
        /// Create a Tree service
        /// </summary>
        /// <returns>A Tree Service</returns>
        ITreeService CreateTreeService();
    }
}