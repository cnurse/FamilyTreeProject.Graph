namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// Defines the methods to create Family Tree Service classes
    /// </summary>
    public interface IFamilyTreeServiceFactory
    {
        /// <summary>
        /// Create a Source service
        /// </summary>
        /// <returns>A Source Service</returns>
        ISourceService CreateSourceService();
        
        /// <summary>
        /// Create a Repository service
        /// </summary>
        /// <returns>A Repository Service</returns>
        IRepositoryService CreateRepositoryService();
        
        /// <summary>
        /// Create a Tree service
        /// </summary>
        /// <returns>A Tree Service</returns>
        ITreeService CreateTreeService();
    }
}