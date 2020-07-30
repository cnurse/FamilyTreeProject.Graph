using System;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Edges
{
    /// <summary>
    /// Represents the TreeContains relationship, for the Tree Vertex type
    /// </summary>
    public class TreeContains<V> : Edge<Tree, V> where V : FamilyTreeVertexBase
    {
        /// <summary>
        /// Constructs a TreeContains relationship
        /// </summary>
        /// <param name="source">The source Tree</param>
        /// <param name="target">The target Vertx</param>
        public TreeContains(Tree source, V target) : this(String.Empty, source, target)
        {
        }

        /// <summary>
        /// Constructs a TreeContains relationship
        /// </summary>
        /// <param name="id">The id of the relationship</param>
        /// <param name="source">The source Tree</param>
        /// <param name="target">The target Vertx</param>
        public TreeContains(string id, Tree source, V target) : base(id, EdgeType.Contains, source, target)
        {
        }
    }
}