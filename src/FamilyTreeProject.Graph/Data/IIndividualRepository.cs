using System.Collections.Generic;
using FamilyTreeProject.Common.Data;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Data
{
    public interface IIndividualRepository : IRepository, IVertexRepository<Individual>
    {
        /// <summary>
        /// Gets a list of Individuals
        /// </summary>
        /// <param name="treeId">The Id of the tree which contains the indivduals</param>
        /// <param name="pageIndex">The page Index</param>
        /// <param name="pageSize">The page size</param>
        /// <returns>An IEnumerable of Individuals</returns>
        IEnumerable<Individual> Get(string treeId, int pageIndex, int pageSize);    
        
        /// <summary>
        /// Gets an individual by Id
        /// </summary>
        /// <param name="id">The individual's id</param>
        /// <returns>An Individual</returns>
        Individual GetById(string id);
    }
}