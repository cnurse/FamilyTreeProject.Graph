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
        /// <returns>A Citation Service</returns>
        ICitationService CreateCitationService();

        /// <summary>
        /// Create a Fact service
        /// </summary>
        /// <returns>A Fact Service</returns>
        IFactService CreateFactService();

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
        /// Create a HasHomeIndividual service
        /// </summary>
        /// <returns>A HasHomeIndividual Service</returns>
        IHasHomeIndividualService CreateHasHomeIndividualService();

        /// <summary>
        /// Create a HasNoteService service
        /// </summary>
        /// <returns>A HasNoteService Service</returns>
        IHasService<Note> CreateHasNoteService();

        /// <summary>
        /// Create an Individual service
        /// </summary>
        /// <returns>An Individual Service</returns>
        IIndividualService CreateIndividualService();

        /// <summary>
        /// Create a Note service
        /// </summary>
        /// <returns>A Note Service</returns>
        INoteService CreateNoteService();

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
        /// <returns>A Repository Service</returns>
        IRepositoryService CreateRepositoryService();
        
        /// <summary>
        /// Create a Source service
        /// </summary>
        /// <returns>A Source Service</returns>
        ISourceService CreateSourceService();
        
        /// <summary>
        /// Create a Spouse service
        /// </summary>
        /// <returns>A Spouse Service</returns>
        ISpouseService CreateSpouseService();

        /// <summary>
        /// Create a Tree service
        /// </summary>
        /// <returns>A Tree Service</returns>
        ITreeService CreateTreeService();
    }
}