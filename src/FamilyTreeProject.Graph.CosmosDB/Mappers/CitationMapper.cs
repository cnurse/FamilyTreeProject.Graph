using FamilyTreeProject.Graph.CosmosDB.DataModels;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.CosmosDB.Mappers
{
    public static class CitationMapper
    {
        /// <summary>
        /// Converts a Citation to a CitationModel
        /// </summary>
        /// <param name="citation">The Citation to convert</param>
        /// <returns>A CitationModel</returns>
        public static CitationModel ToDataModel(this Citation citation)
        {
            return new CitationModel
            {
                Id = citation.Id,
                TreeId = citation.TreeId,
                Date = citation.Date,
                Page = citation.Page,
                Text = citation.Text
            };
        }
    }
}