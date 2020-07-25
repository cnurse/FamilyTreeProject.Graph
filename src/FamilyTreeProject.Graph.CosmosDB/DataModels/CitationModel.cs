using CosmosDB.Net.Domain.Attributes;

namespace FamilyTreeProject.Graph.CosmosDB.DataModels
{
    /// <summary>
    /// Models the Citation Vertex
    /// </summary>
    [Label(Value="Citation")]
    public class CitationModel : BaseVertexModel
    {
        /// <summary>
        /// Gets or sets the Date of the Citation
        /// </summary>
        public string Date  { get; set; }

        /// <summary>
        /// Gets or sets the page number of the citation within the Source
        /// </summary>
        public string Page  { get; set; }

        /// <summary>
        /// Gets or sets the text of the citation
        /// </summary>
        public string Text  { get; set; }
    }
}