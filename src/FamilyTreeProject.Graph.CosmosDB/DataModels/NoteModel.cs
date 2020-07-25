using CosmosDB.Net.Domain.Attributes;

namespace FamilyTreeProject.Graph.CosmosDB.DataModels
{
    /// <summary>
    /// Models the Note vertex
    /// </summary>
    [Label(Value="Note")]
    public class NoteModel: BaseVertexModel
    {   
        /// <summary>
        /// Gets and sets the Text
        /// </summary>
        public string Text { get; set; }
    }
}