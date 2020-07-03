using System;
using System.Collections.Generic;
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
        public Repository(string id, string treeId) : base(id, VertexType.Repository, treeId)
        {
            Address = String.Empty;
            Name = String.Empty;
            Sources = new List<Has<Source>>();
        }
        
        /// <summary>
        /// The Address of the Repository
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The Name of the Repository
        /// </summary>
        public string Name { get; set; }
        
        //Edge Properties
        
        /// <summary>
        /// Gets or sets the Tree this Repository belongs to
        /// </summary>
        public BelongsToTree Tree { get; set; }
        
        /// <summary>
        /// Gets the Sources in this Repository
        /// </summary>
        public IList<Has<Source>> Sources { get; }
    }
}