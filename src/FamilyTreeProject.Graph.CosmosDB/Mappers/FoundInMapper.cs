using FamilyTreeProject.Graph.CosmosDB.DataModels;
using FamilyTreeProject.Graph.Edges;

namespace FamilyTreeProject.Graph.CosmosDB.Mappers
{
    /// <summary>
    /// A mapper class to convert FoundIn edges to FoundInModels and vice versa
    /// </summary>
    public static class FoundInMapper
    {
        /// <summary>
        /// Convert a Found_In to a FoundInModel
        /// </summary>
        /// <param name="foundIn">The Found_In edge to convert</param>
        /// <returns>A FoundInModel</returns>
        public static FoundInModel ToDataModel(this FoundIn foundIn)
        {
            return new FoundInModel()
            {
                Id = foundIn.Id
            };
        }
    }
}