using CosmosDB.Net.Domain.Attributes;

namespace FamilyTreeProject.Graph.CosmosDB.DataModels
{
    /// <summary>
    /// Models the Parent edge
    /// </summary>
    [Label(Value="Parent")]
    public class ParentModel : BaseModel
    {
        /// <summary>
        /// Gets or sets the ParentType of the Parent
        /// </summary>
        public string ParentType { get; set; }
        
    }
}