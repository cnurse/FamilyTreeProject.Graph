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
        /// Constructs a source
        /// </summary>
        /// <param name="repository">The Repository where the source is found</param>
        public Source(Repository repository) : this(String.Empty, String.Empty)
        {
            Repository = new FoundIn(this, repository);
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
            // Citations = new List<Has<Citation>>();
        }
        
        /// <summary>
        /// Gets and sets the Author of the Source
        /// </summary>
        public string Author  
        {
            get => Properties["author"];
            set => Properties["author"] = value;
        }
        
        /// <summary>
        /// Gets and sets the Publisher of the Source
        /// </summary>
        public string Publisher  
        {
            get => Properties["publisher"];
            set => Properties["publisher"] = value;
        }

       /// <summary>
        /// Gets and sets the Title of the Source
        /// </summary>
        public string Title  
       {
           get => Properties["title"];
           set => Properties["title"] = value;
       }
       
       //Edge properties
       
       /*/// <summary>
       /// Gets and sets the citations for this source
       /// </summary>
       public IList<Has<Citation>> Citations { get; set; }*/
       
       /// <summary>
       /// Gets and sets the Repository the Source is Found_In
       /// </summary>
       public FoundIn Repository { get; set; }

       /// <summary>
       /// Gets or sets the Tree this Repository belongs to
       /// </summary>
       public BelongsToTree Tree { get; set; }
    }
}