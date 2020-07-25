using System;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Edges
{
    /// <summary>
    /// Represents the FoundIn edge - Sources are Found In a Repository
    /// </summary>
    public class FoundIn : Edge<Source, Repository>
    {
        /// <summary>
        /// Constructs a FoundIn edge
        /// </summary>
        /// <param name="source">The Source vertex</param>
        /// <param name="target">The Repository vertex</param>
        public FoundIn(Source source, Repository target) : this(String.Empty, source, target)
        {
        }

        /// <summary>
        /// Constructs a FoundIn edge
        /// </summary>
        /// <param name="id">The Id of the Found_In edge</param>
        /// <param name="source">The Source vertex</param>
        /// <param name="target">The Repository vertex</param>
        public FoundIn(string id, Source source, Repository target) : base(id, EdgeType.Found_In, source, target)
        {
        }
    }
}