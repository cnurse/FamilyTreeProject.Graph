using System.Collections.Generic;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Services.Interfaces
{
    /// <summary>
    /// IFactService defines the methods to manage a Fact object
    /// </summary>
    public interface IFactService : IFamilyTreeVertexService<Fact>
    {
        /// <summary>
        /// Gets a list of Facts for an Individual
        /// </summary>
        /// <param name="individualId">The individual's id</param>
        /// <returns>An IEnumerable of Facts</returns>
        IEnumerable<Fact> Get(string individualId);
    }

}