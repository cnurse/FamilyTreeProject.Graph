using System;
using FamilyTreeProject.Common;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Edges;

namespace FamilyTreeProject.Graph.Vertices
{
    /// <summary>
    /// Represents a Repository
    /// </summary>
    public class Repository : FamilyTreeVertexBase
    {
        /// <summary>
        /// Construct a Repository
        /// </summary>
        public Repository() : this(String.Empty, String.Empty)
        {
        }
        
        /// <summary>
        /// Construct a Repository
        /// </summary>
        /// <param name="id">The id of the Repository</param>
        /// <param name="treeId">The id of the Tree which owns the Repository</param>
        public Repository(string id, string treeId) : base(id, EntityType.Repository, treeId)
        {
            Address = String.Empty;
            Name = String.Empty;
            //Sources = new List<Has<Source>>();
        }
        
        /// <summary>
        /// The Address of the Repository
        /// </summary>
        public string Address  
        {
            get => Properties["address"];
            set => Properties["address"] = value;
        }

        /// <summary>
        /// The Name of the Repository
        /// </summary>
        public string Name  
        {
            get => Properties["name"];
            set => Properties["name"] = value;
        }
        
        //Edge Properties
        
        /*/// <summary>
        /// Gets the Sources in this Repository
        /// </summary>
        public IList<Has<Source>> Sources { get; }*/
        
        /// <summary>
        /// Gets or sets the Tree this Repository belongs to
        /// </summary>
        public BelongsToTree Tree { get; set; }

        /*/// <summary>
        /// Adds a source to the repository
        /// </summary>
        /// <param name="source">The source to add</param>
        public void AddSource(Source source)
        {
            Sources.Add(new Has<Source>(this, source));
        }*/
    }
}