using FamilyTreeProject.Graph.Data.DataModels;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Data.Mappers
{
    /// <summary>
    /// A mapper class to convert Repositories to RepositoryModels and vice versa
    /// </summary>
    public static class RepositoryMapper
    {
        /// <summary>
        /// Convert a Repository to a RepositoryModel
        /// </summary>
        /// <param name="repository">The Repository to convert</param>
        /// <returns>A RepositoryModel</returns>
        public static RepositoryModel ToDataModel(this Repository repository)
        {
            return new RepositoryModel
            {
                Id = repository.Id,
                TreeId = repository.TreeId,
                Address = repository.Address,
                Name = repository.Name
            };
        }
    }
}