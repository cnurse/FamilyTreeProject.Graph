using FamilyTreeProject.Graph.Data.DataModels;
using FamilyTreeProject.Graph.Edges;

namespace FamilyTreeProject.Graph.Data.Mappers
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
        public static FoundInModel ToDataModel(this Found_In foundIn)
        {
            return new FoundInModel()
            {
                Id = foundIn.Id
            };
        }
    }
}