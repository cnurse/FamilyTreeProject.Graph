using System;
using FamilyTreeProject.Graph.Common;

namespace FamilyTreeProject.Graph.Vertices
{
    /// <summary>
    /// Represents a Multimedia object
    /// </summary>
    public class MultiMedia : FamilyTreeVertexBase
    {
        /// <summary>
        /// Constructs a Multimedia object
        /// </summary>
        public MultiMedia() : this(String.Empty, String.Empty)
        {
        }
        
        /// <summary>
        /// Constructs a Multimedia object
        /// </summary>
        /// <param name="id">The id of the Multimedia object</param>
        /// <param name="treeId">The id of the tree that owns this Multimedia object</param>
        public MultiMedia(string id, string treeId) : base(id, VertexType.Multimedia, treeId)
        {
            File = String.Empty;
            Format = String.Empty;
            Title = String.Empty;
        }
        
        /// <summary>
        /// The file path (or Uri)
        /// </summary>
        public string File 
        {
            get => Properties["file"];
            set => Properties["file"] = value;
        }

        /// <summary>
        /// The type of the multimedia (jpg, mp3 etc)
        /// </summary>
        public string Format 
        {
            get => Properties["format"];
            set => Properties["format"] = value;
        }

        /// <summary>
        /// The title of the Multimedia
        /// </summary>
        public string Title 
        {
            get => Properties["title"];
            set => Properties["title"] = value;
        }
    }
}