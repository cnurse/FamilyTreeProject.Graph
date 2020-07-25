using FamilyTreeProject.Graph.CosmosDB.DataModels;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.CosmosDB.Mappers
{
    /// <summary>
    /// A mapper class to convert Sources to SourceModels and vice versa
    /// </summary>
    public static class SourceMapper
    {
        /// <summary>
        /// Convert a Source to a SourceModel
        /// </summary>
        /// <param name="source">The Source to convert</param>
        /// <returns>A SourceModel</returns>
        public static SourceModel ToDataModel(this Source source)
        {
            return new SourceModel
            {
                Id = source.Id,
                TreeId = source.TreeId,
                Author = source.Author,
                Publisher = source.Publisher,
                Title = source.Title
            };
        }
    }
}