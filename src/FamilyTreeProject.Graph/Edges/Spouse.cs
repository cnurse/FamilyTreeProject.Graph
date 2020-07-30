using System;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Edges
{
    /// <summary>
    /// Represents the Spouse relationship
    /// </summary>
    public class Spouse : Edge<Individual, Individual>
    {
        /// <summary>
        /// Constructs a Spouse relationship
        /// </summary>
        /// <param name="source">The source individual</param>
        /// <param name="spouse">The spouse individual</param>
        public Spouse(Individual source, Individual spouse) : this(String.Empty, source, spouse)
        {
            
        }
        
        /// <summary>
        /// Constructs a Spouse relationship
        /// </summary>
        /// <param name="id">The id for the relationship</param>
        /// <param name="source">The source individual</param>
        /// <param name="spouse">The spouse individual</param>
        public Spouse(string id, Individual source, Individual spouse) : base(id, EdgeType.Spouse, source, spouse)
        {
        }
    }
}