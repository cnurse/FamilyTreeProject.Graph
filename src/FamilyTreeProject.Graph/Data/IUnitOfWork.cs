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
        /// <typeparam name="E">The type of the Edge</typeparam>
        /// <returns>An Edge repository</returns>
        IEdgeRepository<E> GetEdgeRepository<E>() where E : Element;

        /// <summary>
        /// Get a Vertex Repository
        /// </summary>
        /// <typeparam name="V">The type of the Vertex</typeparam>
        /// <returns></returns>
        IVertexRepository<V> GetVertexRepository<V>() where V : Vertex;
        
        /// <summary>
        /// Get a Repository
        /// </summary>
        /// <typeparam name="V">The type of the Repository</typeparam>
        /// <returns>An IRepository</returns>
        V GetRepository<V>() where V : IRepository;

    }
}