using FamilyTreeProject.Graph.CosmosDB.DataModels;
using FamilyTreeProject.Graph.Edges;

namespace FamilyTreeProject.Graph.CosmosDB.Mappers
{
    /// <summary>
    /// A mapper class to convert BelongsToTree edges to BelongsToTreeModels and vice versa
    /// </summary>
    public static class BelongsToTreeMapper
    {
        /// <summary>
        /// Convert a BelongsToTree to a BelongsToTreeModel
        /// </summary>
        /// <param name="belongsToTree">The BelongsToTree edge to convert</param>
        /// <returns>A BelongsToTreeModel</returns>
        public static BelongsToTreeModel ToDataModel(this BelongsToTree belongsToTree)
        {
            return new BelongsToTreeModel()
            {
                Id = belongsToTree.Id
            };
        }
    }
}