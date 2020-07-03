using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// Defines an interface to define methods for a Family Tree service for a FamilyTreeVertexBase
    /// </summary>
    /// <typeparam name="V">The FamilyTreeVertexBase</typeparam>
    public interface IFamilyTreeVertexService<V> where V : FamilyTreeVertexBase
    {
        /// <summary>
        /// Adds a FamilyTreeVertexBase to the data store
        /// </summary>
        /// <param name="item">The FamilyTreeVertexBase to add</param>
        /// <param name="tree">The Tree the FamilyTreeVertexBase belongs to</param>
        /// <param name="addEdges">A flag that determines whether the edges are added</param>
        void Add(V item, Tree tree, bool addEdges);
    }
}