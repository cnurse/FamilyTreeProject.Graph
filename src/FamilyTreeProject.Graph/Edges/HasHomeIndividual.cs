using System;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Edges
{
    /// <summary>
    /// The HasHomeIndividual Edge defines the relationship between a Tree object and the
    /// Individual considered to be the Home Individual
    /// </summary>
    public class HasHomeIndividual : Edge<Tree, Individual>
    {
        /// <summary>
        /// Constructs a HasHomeIndividual Relationship
        /// </summary>
        /// <param name="source">The source Tree</param>
        /// <param name="target">The target Individual</param>
        public HasHomeIndividual(Tree source, Individual target) : this(String.Empty, source, target)
        {
        }

        /// <summary>
        /// Constructs a HasHomeIndividual Relationship
        /// </summary>
        /// <param name="id">The id for the HasHomeIndividual relationship</param>
        /// <param name="source">The source Tree</param>
        /// <param name="target">The target Individual</param>
        public HasHomeIndividual(string id, Tree source, Individual target) : base(id, EdgeType.Has_Home_Individual, source, target)
        {
        }
    }
}