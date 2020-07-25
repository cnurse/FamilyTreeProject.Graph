using FamilyTreeProject.Graph.CosmosDB.DataModels;
using FamilyTreeProject.Graph.Edges;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.CosmosDB.Mappers
{
    /// <summary>
    /// A mapper class to convert TreeContains edges to TreeContainsModels and vice versa
    /// </summary>
    public static class TreeContainsMapper
    {
        /// <summary>
        /// Converts a TreeContains<Individual> to a TreeContainsModel
        /// </summary>
        /// <param name="contains">The TreeContains<Individual> object to convert</param>
        /// <returns>a TreeContainsModel</returns>
        public static TreeContainsModel ToDataModel(this TreeContains<Individual> contains)
        {
            return ToDataModelInternal(contains.Id);
        }
        
        /// <summary>
        /// Converts a TreeContains<Repository> to a TreeContainsModel
        /// </summary>
        /// <param name="contains">The TreeContains<Repository> object to convert</param>
        /// <returns>a TreeContainsModel</returns>
        public static TreeContainsModel ToDataModel(this TreeContains<Repository> contains)
        {
            return ToDataModelInternal(contains.Id);
        }

        /// <summary>
        /// Converts a TreeContains<Source> to a TreeContainsModel
        /// </summary>
        /// <param name="contains">The TreeContains<Source> object to convert</param>
        /// <returns>a TreeContainsModel</returns>
        public static TreeContainsModel ToDataModel(this TreeContains<Source> contains)
        {
            return ToDataModelInternal(contains.Id);
        }

        private static TreeContainsModel ToDataModelInternal(string id)
        {
            return new TreeContainsModel()
            {
                Id = id
            };
            
        }
    }
}