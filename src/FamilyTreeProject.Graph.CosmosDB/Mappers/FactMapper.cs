using FamilyTreeProject.Graph.CosmosDB.DataModels;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.CosmosDB.Mappers
{
    /// <summary>
    /// A mapper class to convert Facts to FactModels and vice versa
    /// </summary>
    public static class FactMapper
    {
        /// <summary>
        /// Converts a Fact to a FactModel
        /// </summary>
        /// <param name="fact">The Fact to convert</param>
        /// <returns>A FactModel</returns>
        public static FactModel ToDataModel(this Fact fact)
        {
            return new FactModel
            {
                Id = fact.Id,
                TreeId = fact.TreeId,
                Date = fact.Date,
                Description = fact.Description,
                FactType =  fact.FactType.ToString(),
                Place = fact.Place
            };
        }
    }
}