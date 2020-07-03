using FamilyTreeProject.Graph.Data.DataModels;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Data.Mappers
{
    /// <summary>
    /// A mapper class to convert Trees to TreeModels and vice versa
    /// </summary>
    public static class TreeMapper
    {
        /// <summary>
        /// Convert a Tree to a TreeModel
        /// </summary>
        /// <param name="tree">The Tree to convert</param>
        /// <returns>A TreeModel</returns>
        public static TreeModel ToDataModel(this Tree tree)
        {
            return new TreeModel
            {
                Id = tree.Id,
                TreeId = tree.TreeId,
                Description = tree.Description,
                Name = tree.Name,
                Owner = tree.Owner,
                Title = tree.Title,
            };
        }
    }
}