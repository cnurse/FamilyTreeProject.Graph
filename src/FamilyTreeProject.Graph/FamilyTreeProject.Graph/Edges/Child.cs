using System;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Edges
{
    /// <summary>
    /// Represents the Child relationship
    /// </summary>
    public class Child : Edge<Individual, Individual>
    {
        /// <summary>
        /// Constructs a Child relationship
        /// </summary>
        /// <param name="parent">The parent Individual</param>
        /// <param name="child">The child Individual</param>
        public Child(Individual parent, Individual child) : this(String.Empty, parent, child)
        {
            
        }
        
        /// <summary>
        /// Constructs a Child relationship
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parent">The parent Individual</param>
        /// <param name="child">The child Individual</param>
        public Child(string id, Individual parent, Individual child) : base(id, EdgeType.Child, parent, child)
        {
        }
    }
}