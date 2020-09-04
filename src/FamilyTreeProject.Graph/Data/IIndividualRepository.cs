using System.Collections.Generic;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Data
{
    public interface IIndividualRepository : IRepository, IVertexRepository<Individual>
    {
        /// <summary>
        /// Gets a list of Individuals
        /// </summary>
        /// <param name="pageIndex">The page Index</param>
        /// <param name="pageSize">The page size</param>
        /// <returns>An IEnumerable of Individuals</returns>
        IEnumerable<Individual> Get(int pageIndex, int pageSize);    
        
        /// <summary>
        /// Gets an individual by Id
        /// </summary>
        /// <param name="id">The individual's id</param>
        /// <returns>An Individual</returns>
        Individual GetById(string id);
    }
}