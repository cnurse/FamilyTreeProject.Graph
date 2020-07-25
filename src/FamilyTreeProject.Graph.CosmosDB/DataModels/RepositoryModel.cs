using CosmosDB.Net.Domain.Attributes;

namespace FamilyTreeProject.Graph.CosmosDB.DataModels
{
    /// <summary>
    /// Models the Repository vertex
    /// </summary>
    [Label(Value="Repository")]
    public class RepositoryModel : BaseVertexModel
    {
        /// <summary>
        /// Gets and sets the Address
        /// </summary>
        public string Address { get; set; }
        
        /// <summary>
        /// Gets and sets the Name
        /// </summary>
        public string Name { get; set; }
    }
}