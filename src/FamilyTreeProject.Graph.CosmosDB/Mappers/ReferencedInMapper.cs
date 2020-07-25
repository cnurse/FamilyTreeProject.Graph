using FamilyTreeProject.Graph.CosmosDB.DataModels;
using FamilyTreeProject.Graph.Edges;

namespace FamilyTreeProject.Graph.CosmosDB.Mappers
{
    /// <summary>
    /// A mapper class to convert ReferencedIn edges to ReferencedInModels and vice versa
    /// </summary>
    public static class ReferencedInMapper
    {
        /// <summary>
        /// Convert a ReferencedIn to a ReferencedInModel
        /// </summary>
        /// <param name="referencedIn">The ReferencedIn edge to convert</param>
        /// <returns>A ReferencedInModel</returns>
        public static ReferencedInModel ToDataModel(this ReferencedIn referencedIn)
        {
            return new ReferencedInModel()
            {
                Id = referencedIn.Id
            };
        }
    }
}