using System.Collections.Generic;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Services.Interfaces
{
    /// <summary>
    /// IIndividualService defines the methods to manage a Individual object
    /// </summary>
    public interface IIndividualService : IFamilyTreeVertexService<Individual>
    {
        /// <summary>
        /// Gets a list of Individuals
        /// </summary>
        /// <param name="treeId">The Id of the tree which contains the indivduals</param>
        /// <param name="pageIndex">The page Index</param>
        /// <param name="pageSize">The page size</param>
        /// <param name="includeFacts">A flag that determines whether an individual's facts should be returned</param>
        /// <param name="includeNotes">A flag that determines whether an individual's notes should be returned</param>
        /// <returns>An IEnumerable of Individuals</returns>
        IEnumerable<Individual> Get(string treeId, int pageIndex, int pageSize, bool includeFacts, bool includeNotes);
        
        /// <summary>
        /// Gets an individual by Id
        /// </summary>
        /// <param name="id">The individual's id</param>
        /// <param name="includeFacts">A flag that determines whether an individual's facts should be returned</param>
        /// <param name="includeNotes">A flag that determines whether an individual's notes should be returned</param>
        /// <returns>An Individual</returns>
        Individual GetById(string id, bool includeFacts, bool includeNotes);
    }
}