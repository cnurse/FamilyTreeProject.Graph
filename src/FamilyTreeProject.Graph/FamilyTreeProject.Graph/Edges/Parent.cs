using System;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Edges
{
    /// <summary>
    /// Represents the Parent relationship
    /// </summary>
    public class Parent: Edge<Individual, Individual>
    {
        /// <summary>
        /// Constructs a Parent relationship
        /// </summary>
        /// <param name="child">The child Individual</param>
        /// <param name="parent">The parent Individual</param>
        /// <param name="parentType">The type of parent</param>
        public Parent(Individual child, Individual parent, ParentType parentType) : this(String.Empty, child, parent, parentType)
        {
            
        }

        /// <summary>
        /// Constructs a Parent relationship
        /// </summary>
        /// <param name="id">The id of the relationship</param>
        /// <param name="child">The child Individual</param>
        /// <param name="parent">The parent Individual</param>
        /// <param name="parentType">The type of parent</param>
        public Parent(string id, Individual child, Individual parent, ParentType parentType) : base(id, EdgeType.Parent, child, parent)
        {
            ParentType = parentType;
        }
        
        /// <summary>
        /// The type of parent
        /// </summary>
        public ParentType ParentType
        {
            get => (ParentType) Enum.Parse(typeof(ParentType), Properties["parentType"]);
            set => Properties["parentType"] = value.ToString();
        }
    }
}