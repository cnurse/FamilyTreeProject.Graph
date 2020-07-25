using FamilyTreeProject.Graph.Edges;

namespace FamilyTreeProject.Graph.Services.Interfaces
{
    /// <summary>
    /// The IFoundInService defines the methods to manage FoundIn edge objects
    /// </summary>
    public interface IFoundInService
    {
        /// <summary>
        /// Adds a FoundIn edge to the data store
        /// </summary>
        /// <param name="foundIn">The FoundIn edge to add</param>
        void Add(FoundIn foundIn);
    }
}