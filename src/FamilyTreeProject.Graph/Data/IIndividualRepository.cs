using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Data
{
    public interface IIndividualRepository: IRepository, IVertexRepository<Individual>
    {
        /// <summary>
        /// Gets an individual by Id
        /// </summary>
        /// <param name="id">The individual's id</param>
        /// <returns>An Individual</returns>
        Individual GetById(string id);
    }