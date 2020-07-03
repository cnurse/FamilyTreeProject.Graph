using CosmosDB.Net.Domain.Attributes;

namespace FamilyTreeProject.Graph.Data.DataModels
{
    /// <summary>
    /// A Base class for vertices
    /// </summary>
    public abstract class BaseVertexModel : BaseModel
    {
        /// <summary>
        /// Gets and sets the TreeId
        /// </summary>
        [PartitionKey]
        public string TreeId { get; set; }
    }
}