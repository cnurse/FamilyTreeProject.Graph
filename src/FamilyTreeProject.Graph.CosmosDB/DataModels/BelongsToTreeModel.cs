using CosmosDB.Net.Domain.Attributes;

namespace FamilyTreeProject.Graph.CosmosDB.DataModels
{
    /// <summary>
    /// Models the Belongs_To edge
    /// </summary>
    [Label(Value="Belongs_To")]
    public class BelongsToTreeModel : BaseModel
    {
    }
}