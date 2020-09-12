using System;
using FamilyTreeProject.Common;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Edges;

namespace FamilyTreeProject.Graph.Vertices
{
    /// <summary>
    /// Represents a Citation
    /// </summary>
    public class Citation : FamilyTreeVertexBase
    {
        /// <summary>
        /// Constructs a Citation
        /// </summary>
        public Citation() : this(String.Empty, String.Empty)
        {
        }

        /// <summary>
        /// Constructs a new Citation using a Source
        /// </summary>
        /// <param name="source">The Source whic contains this Citation</param>
        public Citation(Source source) : this(String.Empty, String.Empty)
        {
            Source = new ReferencedIn(this, source);
        }
        
        /// <summary>
        /// Constructs a Citation
        /// </summary>
        /// <param name="id">The id of the Fact</param>
        /// <param name="treeId">The Id of the tree that owns the fact</param>
        public Citation(string id, string treeId) : base(id, EntityType.Citation, treeId)
        {
            Date = String.Empty;
            Page = String.Empty;
            Text = String.Empty;
        }

        /// <summary>
        /// The Date of the Citation
        /// </summary>
        public string Date 
        {
            get => Properties["date"];
            set => Properties["date"] = value;
        }

        /// <summary>
        /// The page number of the citation within the Source
        /// </summary>
        public string Page 
        {
            get => Properties["page"];
            set => Properties["page"] = value;
        }

        /// <summary>
        /// The text of the citation
        /// </summary>
        public string Text 
        {
            get => Properties["text"];
            set => Properties["text"] = value;
        }
        
        //Edge properties
        public ReferencedIn Source { get; set; }
    }
}