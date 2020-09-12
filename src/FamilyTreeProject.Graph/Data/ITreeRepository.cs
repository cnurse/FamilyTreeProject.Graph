using System.Collections.Generic;
using FamilyTreeProject.Common.Data;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Data
{
    /// <summary>
    /// Defines a repository for managing trees
    /// </summary>
    public interface ITreeRepository : IRepository, IVertexRepository<Tree>
    {
        /// <summary>
        /// Gets all the trees belonging to a user (owner)
        /// </summary>
        /// <param name="owner">The owner of the trees</param>
        /// <returns>An IEnumerable of Trees</returns>
        IEnumerable<Tree> Get(string owner);
    }
}