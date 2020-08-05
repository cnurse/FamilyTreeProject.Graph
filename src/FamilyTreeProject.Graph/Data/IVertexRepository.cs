using System.Collections.Generic;
using FamilyTreeProject.Graph.Common;

namespace FamilyTreeProject.Graph.Data
{
    /// <summary>
    /// Defines a simple generic repository for managing vertices
    /// </summary>
    /// <typeparam name="V">The vertex type</typeparam>
    public interface IVertexRepository<V> where V : IVertex
    {
        /// <summary>
        /// Add a vertex into the repository
        /// </summary>
        /// <param name="vertex">The vertex to be added</param>
        void Add(V vertex);
        
        /// <summary>
        /// Gets a FamilyTreeVertexBase from the data store, based on its Id
        /// </summary>
        /// <param name="id">The Id of the FamilyTreeVertexBase to get</param>
        /// <returns>The FamilyTreeVertex Base</returns>
        V GetById(string id);
    }
}