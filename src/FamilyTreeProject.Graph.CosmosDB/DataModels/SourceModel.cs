using CosmosDB.Net.Domain.Attributes;

namespace FamilyTreeProject.Graph.CosmosDB.DataModels
{
    /// <summary>
    /// Models the Source vertex
    /// </summary>
    [Label(Value="Source")]
    public class SourceModel: BaseVertexModel
    {
        /// <summary>
        /// Gets and sets the Author of the Source
        /// </summary>
        public string Author { get; set; }
        
        /// <summary>
        /// Gets and sets the Publisher of the Source
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// Gets and sets the Title of the Source
        /// </summary>
        public string Title { get; set; }
    }
}