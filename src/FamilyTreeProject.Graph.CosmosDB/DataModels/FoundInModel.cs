using CosmosDB.Net.Domain.Attributes;

namespace FamilyTreeProject.Graph.CosmosDB.DataModels
{
    /// <summary>
    /// Models the Found_In edge
    /// </summary>
    [Label(Value="Found_In")]
    public class FoundInModel : BaseModel
    {
    }
}