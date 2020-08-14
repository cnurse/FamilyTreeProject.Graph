using System.Collections.Generic;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Services.Interfaces
{
    /// <summary>
    /// The ITreeService defines the methods to manage tree objects
    /// </summary>
    public interface ITreeService
    {
        /// <summary>
        /// Adds a Tree object to the data store
        /// </summary>
        /// <param name="tree">The tree to add</param>
        void Add(Tree tree);

        /// <summary>
        /// Gets all the Trees owned by a user
        /// </summary>
        /// <param name="owner">The owner's id</param>
        /// <returns>An IEnumerable of Trees</returns>
        IEnumerable<Tree> GetTrees(string owner);

        /// <summary>
        /// Set the Home Individual for a Tree
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <param name="individual">The individual to make Home Individual</param>
        void SetHomeIndividual(Tree tree, Individual individual);
    }
}