using System;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Edges;

namespace FamilyTreeProject.Graph.Vertices
{
    /// <summary>
    /// Models a Family Tree
    /// </summary>
    public class Tree : Vertex
    {
        /// <summary>
        /// Constructs a Tree
        /// </summary>
        public Tree() : this(String.Empty)
        {
        }

        /// <summary>
        /// Constructs a Tree
        /// </summary>
        /// <param name="id">The id of the Tree</param>
        public Tree(string id) : base(id, VertexType.Tree, id)
        {
            Name = String.Empty;
            Title = String.Empty;
            Description = String.Empty;
            Owner = String.Empty;
        }
        
        /// <summary>
        /// Gets and sets the Description of the Tree
        /// </summary>
        public string Description
        {
            get => Properties["description"];
            set => Properties["description"] = value;
        }
        
        /// <summary>
        /// Gets and sets the count of Individuals in the data store
        /// </summary>
        public long IndividualCount { get; set; }
        
        /// <summary>
        /// Gets and sets the Name of the Tree
        /// </summary>
        public string Name
        {
            get => Properties["name"];
            set => Properties["name"] = value;
        }

        /// <summary>
        /// Gets and sets the owner of the tree (this can be used to associate trees with "users")
        /// An implementation system will manage the "owning" of a tree
        /// </summary>
        public string Owner
        {
            get => Properties["owner"];
            set => Properties["owner"] = value;
        }

        /// <summary>
        /// Gets and sets the count of Repositories in the data store
        /// </summary>
        public long RepositoryCount { get; set; }

        /// <summary>
        /// Gets and sets the count of Sources in the data store
        /// </summary>
        public long SourceCount { get; set; }

        /// <summary>
        /// Gets and sets the Title of the Tree
        /// </summary>
        public string Title
        {
            get => Properties["title"];
            set => Properties["title"] = value;
        }
        
        //Edge properties
        
        /// <summary>
        /// Gets or sets the Home Individual for this Tree
        /// </summary>
        public HasHomeIndividual HomeIndividual { get; set; }
    }
}
