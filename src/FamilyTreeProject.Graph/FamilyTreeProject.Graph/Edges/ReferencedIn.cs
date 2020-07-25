using System;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Edges
{
    /// <summary>
    /// Represents the Referenced_In edge - Citations are Referenced In a Source
    /// </summary>
    public class ReferencedIn : Edge<Citation, Source>
    {
        /// <summary>
        /// Constructs a Referenced_In edge
        /// </summary>
        /// <param name="source">The Source vertex</param>
        /// <param name="target">The Repository vertex</param>
        public ReferencedIn(Citation source, Source target) : this(String.Empty, source, target)
        {
        }
        
        /// <summary>
        /// Constructs a Referenced_In edge
        /// </summary>
        /// <param name="id">The Id of the Referenced_In edge</param>
        /// <param name="source">The Citation vertex</param>
        /// <param name="target">The Source vertex</param>
        public ReferencedIn(string id, Citation source, Source target) : base(id, EdgeType.Referenced_In, source, target)
        {
        }
    }
}