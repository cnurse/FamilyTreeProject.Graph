using CosmosDB.Net.Domain.Attributes;

namespace FamilyTreeProject.Graph.CosmosDB.DataModels
{
    /// <summary>
    /// A Base class for a all data Model classes
    /// </summary>
    public abstract class BaseModel
    {
        /// <summary>
        /// Gets and sets the Id
        /// </summary>
        [Id]
        public string Id { get; set; }
    }
}