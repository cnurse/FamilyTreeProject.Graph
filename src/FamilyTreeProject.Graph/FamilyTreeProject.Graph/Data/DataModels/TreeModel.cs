using CosmosDB.Net.Domain.Attributes;

namespace FamilyTreeProject.Graph.Data.DataModels
{
    /// <summary>
    /// Models the Tree vertex
    /// </summary>
    [Label(Value="Tree")]
    public class TreeModel : BaseVertexModel
    {
        /// <summary>
        /// Gets and sets the Description
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Gets and sets the Name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Gets and sets the Owner
        /// </summary>
        public string Owner { get; set; }
        
        /// <summary>
        /// Gets and sets the Title
        /// </summary>
        public string Title { get; set; }
    }
}