using System.Collections.Generic;
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
        /// <param name="tree">The tree the Note belongs to</param>
        void Add(Note note, Tree tree);

        /// <summary>
        /// Gets a list of Notes for an Individual
        /// </summary>
        /// <param name="individualId">The individual's id</param>
        /// <returns>An IEnumerable of Notes</returns>
        IEnumerable<Note> Get(string individualId);
    }
}