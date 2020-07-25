using FamilyTreeProject.Graph.CosmosDB.DataModels;
using FamilyTreeProject.Graph.Edges;

namespace FamilyTreeProject.Graph.CosmosDB.Mappers
{
    /// <summary>
    /// A mapper class to convert Child edges to ChildModels and vice versa
    /// </summary>
    public static class ChildMapper
    {
        /// <summary>
        /// Convert a Child to a ChildModel
        /// </summary>
        /// <param name="child">The Child edge to convert</param>
        /// <returns>A ChildModel</returns>
        public static ChildModel ToDataModel(this Child child)
        {
            return new ChildModel()
            {
                Id = child.Id
            };
        }
    }
}