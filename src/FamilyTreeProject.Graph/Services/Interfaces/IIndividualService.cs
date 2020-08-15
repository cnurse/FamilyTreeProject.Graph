using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Services.Interfaces
{
    /// <summary>
    /// IIndividualService defines the methods to manage a Individual object
    /// </summary>
    public interface IIndividualService : IFamilyTreeVertexService<Individual>
    {
        /// <summary>
        /// Gets an individual by Id
        /// </summary>
        /// <param name="id">The individual's id</param>
        /// <returns>An Individual</returns>
        Individual GetById(string id);
    }
}