using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Services
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
    }
}