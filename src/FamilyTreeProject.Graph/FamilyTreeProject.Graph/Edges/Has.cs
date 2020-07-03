using System;
using FamilyTreeProject.Graph.Common;

namespace FamilyTreeProject.Graph.Edges
{
    /// <summary>
    /// Represents the Has relationship (As in Individual Has Notes)
    /// </summary>
    /// <typeparam name="V">The type of the target</typeparam>
    public class Has<V> : Edge<FamilyTreeVertexBase, V> where V : Vertex
    {
        /// <summary>
        /// Constructs a Has relationship
        /// </summary>
        /// <param name="source">The source FamilyTreeVertexBase object</param>
        /// <param name="target">The target Vertex</param>
        public Has(FamilyTreeVertexBase source, V target) : this(String.Empty, source, target)
        {
        }

        /// <summary>
        /// Constructs a Has relationship
        /// </summary>
        /// <param name="id">The id of the relationship</param>
        /// <param name="source">The source FamilyTreeVertexBase object</param>
        /// <param name="target">The target Vertex</param>
        public Has(string id, FamilyTreeVertexBase source, V target) : base(id, EdgeType.Has, source, target)
        {
        }
    }
}