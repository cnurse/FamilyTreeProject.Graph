using System;
using System.Collections.Generic;

namespace FamilyTreeProject.Graph.Common
{
    /// <summary>
    /// The base class Element, is a base class for both Vertices and Edges, and includes common properties
    /// and fields
    /// </summary>
    public abstract class Element : IElement
    {
        /// <summary>
        /// Constructs an Element.  Constructor is protected as Element is abstract
        /// </summary>
        /// <param name="id">The Id of the Element</param>
        /// <param name="label">The Label - in Graph terminology this is a synonym for the type</param>
        protected Element(string id, string label)
        {
            Id = id;
            Label = label;
            Properties = new Dictionary<string, string>();
        }
        
        /// <summary>
        /// Gets and sets the Id of the Element
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets the Label of the Element.  Note that there is no setter as the Label can only be set on creation
        /// of an Element
        /// </summary>
        public string Label { get; }
        
        /// <summary>
        /// Gets Properties for an Element.  Note that there is no setter as the Properties collection can only be
        /// created on creation of an Element
        /// </summary>
        public IDictionary<string, string> Properties { get; }
    }
}