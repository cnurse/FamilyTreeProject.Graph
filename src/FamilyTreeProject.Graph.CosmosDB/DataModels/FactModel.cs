using CosmosDB.Net.Domain.Attributes;

namespace FamilyTreeProject.Graph.CosmosDB.DataModels
{
    /// <summary>
    /// Models the Fact Vertex
    /// </summary>
    [Label(Value="Fact")]
    public class FactModel :  BaseVertexModel
    {
        /// <summary>
        /// Gets or sets the  date of the fact (if the fact is an event)
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the description of the fact
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Gets or sets the  type of the Fact
        /// </summary>
        public string FactType { get; set; }

        /// <summary>
        /// Gets or sets the  place for the fact
        /// </summary>
        public string Place { get; set; }
    }
}