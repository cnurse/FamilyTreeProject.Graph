using FamilyTreeProject.Graph.CosmosDB.DataModels;
using FamilyTreeProject.Graph.Edges;

namespace FamilyTreeProject.Graph.CosmosDB.Mappers
{
    /// <summary>
    /// A mapper class to convert Spouse edges to SpouseModels and vice versa
    /// </summary>
    public static class SpouseMapper
    {
        /// <summary>
        /// Convert a Spouse to a SpouseModel
        /// </summary>
        /// <param name="spouse">The Spouse edge to convert</param>
        /// <returns>A SpouseModel</returns>
        public static SpouseModel ToDataModel(this Spouse spouse)
        {
            return new SpouseModel()
            {
                Id = spouse.Id
            };
        }
    }
}