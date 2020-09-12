using System.Collections.Generic;
using FamilyTreeProject.Common;
using FamilyTreeProject.Graph.Edges;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Common
{
    /// <summary>
    /// A CitationsVertexBase is a base class for all vertices that have a collection of Citations (Individual, Fact)
    /// </summary>
    public class CitationsVertexBase : FamilyTreeVertexBase
    {
        /// <summary>
        /// Constructs a CitationsVertexBase object
        /// </summary>
        /// <param name="id">The id of the CitationsVertexBase</param>
        /// <param name="vertexType">The vertexType of the CitationsVertexBase</param>
        /// <param name="treeId">The id of the Tree which contains this CitationsVertexBase</param>
        protected CitationsVertexBase(string id, EntityType vertexType, string treeId) : base(id, vertexType, treeId)
        {            
            Citations = new List<Has<Citation>>();
        }
        
        /// <summary>
        /// Gets the Citations for the CitationVertexBase
        /// </summary>
        public IList<Has<Citation>> Citations { get; }

        /// <summary>
        /// Adds a new Citation to the Citations collectio
        /// </summary>
        /// <param name="newCitation">The new Citation to add</param>
        public void AddCitation(Citation newCitation)
        {
            Citations.Add(new Has<Citation>(this, newCitation));
        }
    }
}