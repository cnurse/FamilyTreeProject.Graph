using FamilyTreeProject.Graph.CosmosDB.DataModels;
using FamilyTreeProject.Graph.Edges;

namespace FamilyTreeProject.Graph.CosmosDB.Mappers
{
    /// <summary>
    /// A mapper class to convert Parent edges to ParentModels and vice versa
    /// </summary>
    public static class ParentMapper
    {
        /// <summary>
        /// Convert a Parent to a ParentModel
        /// </summary>
        /// <param name="parent">The Parent edge to convert</param>
        /// <returns>A ParentModel</returns>
        public static ParentModel ToDataModel(this Parent parent)
        {
            return new ParentModel()
            {
                Id = parent.Id,
                ParentType = parent.ParentType.ToString()
            };
        }
    }
}