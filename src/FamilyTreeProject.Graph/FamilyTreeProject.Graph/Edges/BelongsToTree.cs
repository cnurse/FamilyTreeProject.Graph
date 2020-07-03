using System;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Edges
{
    /// <summary>
    /// The BelongsToTree Edge defines the relationship between a FamilyTreeVertexBase object and the
    /// Tree it belongs to - eg Repository Belongs_To a Tree
    /// </summary>
    public class BelongsToTree : Edge<FamilyTreeVertexBase, Tree>
    {
        /// <summary>
        /// Constructs a BelongsToTree Relationship
        /// </summary>
        /// <param name="source">The source FamilyTreeBase</param>
        /// <param name="target">The target Tree</param>
        public BelongsToTree(FamilyTreeVertexBase source, Tree target) : this(String.Empty, source, target)
        {
        }

        /// <summary>
        /// Constructs a BelongsToTree Relationship
        /// </summary>
        /// <param name="id">The id for the Belongs_To_Tree relationship</param>
        /// <param name="source">The source FamilyTreeBase</param>
        /// <param name="target">The target Tree</param>
        public BelongsToTree(string id, FamilyTreeVertexBase source, Tree target) : base(id, EdgeType.Belongs_To_Tree, source, target)
        {
        }
    }
}