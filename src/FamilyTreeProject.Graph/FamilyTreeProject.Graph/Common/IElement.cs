using System.Collections.Generic;

namespace FamilyTreeProject.Graph.Common
{
    public interface IElement
    {
        /// <summary>
        /// Gets and sets the Id of the Element
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// Gets the Label of the Element.  Note that there is no setter as the Label can only be set on creation
        /// of an Element
        /// </summary>
        string Label { get; }
        
        /// <summary>
        /// Gets Properties for an Element.  Note that there is no setter as the Properties collection can only be
        /// created on creation of an Element
        /// </summary>
        IDictionary<string, string> Properties { get; }
    }
}