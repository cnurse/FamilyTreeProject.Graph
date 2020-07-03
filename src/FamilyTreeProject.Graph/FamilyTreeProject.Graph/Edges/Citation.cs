using System;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Edges
{
    /// <summary>
    /// Represents a Source Citation
    /// </summary>
    public class Citation : Edge<FamilyTreeVertexBase, Source>
    {
        /// <summary>
        /// Constructs a Citation
        /// </summary>
        /// <param name="source">The source FamilyTreeVertexBase (Individual or Fact)</param>
        /// <param name="target">The target Source object</param>
        public Citation(FamilyTreeVertexBase source, Source target) :this(String.Empty, source, target)
        {
            
        }
        
        /// <summary>
        /// Constructs a Citation
        /// </summary>
        /// <param name="id">The id of the Citation</param>
        /// <param name="source">The source FamilyTreeVertexBase (Individual or Fact)</param>
        /// <param name="target">The target Source object</param>
        public Citation(string id, FamilyTreeVertexBase source, Source target) : base(id, EdgeType.Citation, source, target)
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
    }
}