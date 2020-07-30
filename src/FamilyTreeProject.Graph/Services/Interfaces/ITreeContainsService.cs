using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Edges;

namespace FamilyTreeProject.Graph.Services.Interfaces
{
    /// <summary>
    /// The ITreeContainsService defines the methods to manage TreeContains edge objects
    /// </summary>
    public interface ITreeContainsService<V> where V : FamilyTreeVertexBase
    {
        /// <summary>
        /// Adds a TreeContains edge to the data store
        /// </summary>
        /// <param name="treeContains">The TreeContains edge to add</param>
        void Add(TreeContains<V> treeContains);

    }
}