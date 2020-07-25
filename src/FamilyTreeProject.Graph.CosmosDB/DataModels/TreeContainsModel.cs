using CosmosDB.Net.Domain.Attributes;

namespace FamilyTreeProject.Graph.CosmosDB.DataModels
{
    /// <summary>
    /// Models the TreeContains edge
    /// </summary>
    [Label(Value="Contains")]
    public class TreeContainsModel : BaseModel
    {
    }
}