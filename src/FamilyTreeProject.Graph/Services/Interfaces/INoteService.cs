using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Services.Interfaces
{
    /// <summary>
    /// INoteService defines the methods to manage a Note object
    /// </summary>
    public interface INoteService
    {
        /// <summary>
        /// Adds a Note object to the data store
        /// </summary>
        /// <param name="note">The note to add</param>
        void Add(Note note);
    }
}