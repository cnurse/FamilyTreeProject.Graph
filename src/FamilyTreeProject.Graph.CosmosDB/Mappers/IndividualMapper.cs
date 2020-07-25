using FamilyTreeProject.Graph.CosmosDB.DataModels;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.CosmosDB.Mappers
{
    /// <summary>
    /// A mapper class to convert Individuals to IndividualModels and vice versa
    /// </summary>
    public static class IndividualMapper
    {
        /// <summary>
        /// Convert an Individual to an IndividualModel
        /// </summary>
        /// <param name="source">The Individual to convert</param>
        /// <returns>An IndividualModel</returns>
        public static IndividualModel ToDataModel(this Individual individual)
        {
            return new IndividualModel
            {
                Id = individual.Id,
                TreeId = individual.TreeId,
                Alive = individual.Alive ?? false,
                FirstName = individual.FirstName,
                LastName = individual.LastName,
                Name = individual.Name,
                Sex = individual.Sex.ToString()
            };
        }
    }
}