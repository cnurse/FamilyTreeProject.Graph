using System.Collections.Generic;
using FamilyTreeProject.Common.Data;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Data
{
    public interface IFactRepository : IRepository, IVertexRepository<Fact>
    {
        /// <summary>
        /// Gets a list of Facts for an Individual
        /// </summary>
        /// <param name="id">The individual's id</param>
        /// <returns>An IEnumerable of Facts</returns>
        IEnumerable<Fact> Get(string id);    
    }
}