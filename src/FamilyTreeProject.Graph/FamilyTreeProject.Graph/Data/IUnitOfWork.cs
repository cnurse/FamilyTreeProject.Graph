using System;
using FamilyTreeProject.Graph.Common;

namespace FamilyTreeProject.Graph.Data
{
    /// <summary>
    /// Defines a Unit Of Work
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// The Commit method is used to commit any unsaved changes
        /// </summary>
        void Commit();

        /// <summary>
        /// Get an EdgeRepository
        /// </summary>
        /// <typeparam name="V1">The type of the Source Vertex</typeparam>
        /// <typeparam name="V2">The type of the Target Vertex</typeparam>
        /// <returns>An Edge repository</returns>
        IEdgeRepository<V1, V2> GetEdgeRepository<V1, V2>() where V1 : Vertex where V2 : Vertex;

        /// <summary>
        /// Get a Vertex Repository
        /// </summary>
        /// <typeparam name="V">The type of the Vertex</typeparam>
        /// <returns></returns>
        IVertexRepository<V> GetVertexRepository<V>() where V : Vertex;
    }
}