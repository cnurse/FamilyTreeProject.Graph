using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Contracts;
using FamilyTreeProject.Graph.Data;
using Neo4j.Driver;

namespace FamilyTreeProject.Graph.Neo4j
{
    /// <summary>
    /// The Neo4jUnitofWork implements the IUnitOfWork interface for Neo4j
    /// </summary>
    public class Neo4jUnitofWork : IUnitOfWork
    {
        private readonly ISession _session;
        
        /// <summary>
        /// Constructs a Neo4jUnitOfWork
        /// </summary>
        /// <param name="driver">The Neo4j Driver</param>
        public Neo4jUnitofWork(IDriver driver)
        {
            Requires.NotNull(driver);
            
            _session = driver.Session();
        }
        
        /// <summary>
        /// Dispose of the Unit of Work
        /// </summary>
        public void Dispose()
        {
            _session.Dispose();
        }

        /// <summary>
        /// Commit any unsaved changes
        /// </summary>
        public void Commit()
        {
        }

        /// <summary>
        /// Get a generic EdgeRepository
        /// </summary>
        /// <typeparam name="E">The type of the edge</typeparam>
        /// <returns>An IEdgeRepository</returns>
        public IEdgeRepository<E> GetEdgeRepository<E>() where E : Element
        {
            return new Neo4jEdgeRepository<E>(_session);
        }

        /// <summary>
        /// Get a generic Vertex Repository
        /// </summary>
        /// <typeparam name="V">The type of the vertex</typeparam>
        /// <returns>An IVertexRepository</returns>
        public IVertexRepository<V> GetVertexRepository<V>() where V : Vertex
        {
            return new Neo4jVertexRepository<V>(_session);
        }
    }
}