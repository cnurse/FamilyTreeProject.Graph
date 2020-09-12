using System;
using FamilyTreeProject.Common;
using FamilyTreeProject.Graph.Common;

namespace FamilyTreeProject.Graph.Vertices
{
    /// <summary>
    /// Represents a Fact
    /// </summary>
    public class Fact : CitationsVertexBase
    {
        /// <summary>
        /// Constructs a Fact
        /// </summary>
        public Fact() : this(String.Empty, String.Empty)
        {
        }
        
        /// <summary>
        /// Constructs a Fact
        /// </summary>
        /// <param name="id">The id of the Fact</param>
        /// <param name="treeId">The Id of the tree that owns the fact</param>
        public Fact(string id, string treeId) : base(id, EntityType.Fact, treeId)
        {
            Date = String.Empty;
            Description = String.Empty;
            FactType = FactType.Unknown;
            Place = String.Empty;
        }
        
        /// <summary>
        /// The date of the fact (if the fact is an event)
        /// </summary>
        public string Date 
        {
            get => Properties["date"];
            set => Properties["date"] = value;
        }

        /// <summary>
        /// The description of the fact
        /// </summary>
        public string Description 
        {
            get => Properties["description"];
            set => Properties["description"] = value;
        }
        
        /// <summary>
        /// The type of the Fact
        /// </summary>
        public FactType FactType 
        {
            get => (FactType) Enum.Parse(typeof(FactType), Properties["factType"]);
            set => Properties["factType"] = value.ToString();
        }

        /// <summary>
        /// The place for the fact
        /// </summary>
        public string Place 
        {
            get => Properties["place"];
            set => Properties["place"] = value;
        }
    }
}