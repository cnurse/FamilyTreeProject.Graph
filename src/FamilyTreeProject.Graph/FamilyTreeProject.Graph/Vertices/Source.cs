using System;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Edges;

namespace FamilyTreeProject.Graph.Vertices
{
    /// <summary>
    /// Represents a Source
    /// </summary>
    public class Source : FamilyTreeVertexBase
    {
        /// <summary>
        /// Construct a Source
        /// </summary>
        public Source() : this(String.Empty, String.Empty)
        {
        }
        
        /// <summary>
        /// Construct a Source
        /// </summary>
        /// <param name="id">The Id of the Source</param>
        /// <param name="treeId">The Id of the Tree where this source is used</param>
        public Source(string id, string treeId) : base(id, VertexType.Source, treeId)
        {
            Author = String.Empty;
            Publisher = String.Empty;
            Title = String.Empty;
            Repository = null;
        }
        
        /// <summary>
        /// Gets and sets the Author of the Source
        /// </summary>
        public string Author { get; set; }
        
        /// <summary>
        /// Gets and sets the Publisher of the Source
        /// </summary>
        public string Publisher { get; set; }

       /// <summary>
        /// Gets and sets the Title of the Source
        /// </summary>
        public string Title { get; set; }
       
       //Edge properties
       
       /// <summary>
       /// Gets and sets the Repository the Source is Found_In
       /// </summary>
       public Found_In Repository { get; set; }

       /// <summary>
       /// Gets or sets the Tree this Repository belongs to
       /// </summary>
       public BelongsToTree Tree { get; set; }
    }
}