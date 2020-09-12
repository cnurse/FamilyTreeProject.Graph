using System;
using FamilyTreeProject.Common;
using FamilyTreeProject.Graph.Common;

namespace FamilyTreeProject.Graph.Vertices
{
    /// <summary>
    /// Represents a Note
    /// </summary>
    public class Note : FamilyTreeVertexBase
    {
        /// <summary>
        /// Constructs a Note
        /// </summary>
        public Note() : this(String.Empty, String.Empty)
        {
            Text = String.Empty;
        }
        
        /// <summary>
        /// Constructs a Note
        /// </summary>
        /// <param name="id">The id of the Note</param>
        /// <param name="treeId">The id of the tree that owns the Note</param>
        public Note(string id, string treeId) : base(id, EntityType.Note, treeId)
        {
        }
        
        /// <summary>
        /// The text of the Note
        /// </summary>
        public string Text  
        {
            get => Properties["text"];
            set => Properties["text"] = value;
        }
    }
}