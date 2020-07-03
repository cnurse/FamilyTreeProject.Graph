using CosmosDB.Net;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Contracts;
using FamilyTreeProject.Graph.Data;

namespace FamilyTreeProject.Graph.CosmosDB
{
    /// <summary>
    /// The CosmosDBUnitOfWork implements the IUnitOfWork interface for Azure CosmosDB
    /// </summary>
    public class CosmosDBUnitOfWork : IUnitOfWork
    {
        private readonly ICosmosClientGraph _cosmosClient;
        
        /// <summary>
        /// Constructs a CosmosDBUnitOFWork
        /// </summary>
        /// <param name="cosmosClient">The CosmosDB Client (using CosmosDB.Net)</param>
        public CosmosDBUnitOfWork(ICosmosClientGraph cosmosClient)
        {
            Requires.NotNull(cosmosClient);
            
            _cosmosClient = cosmosClient;
        }
        
        /// <summary>
        /// Dispose of the Unit of Work
        /// </summary>
        public void Dispose()
        {
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
        /// <typeparam name="V1">The type of the source vertex</typeparam>
        /// <typeparam name="V2">The type of the target vertex</typeparam>
        /// <returns>An IEdgeRepository</returns>
        public IEdgeRepository<V1, V2> GetEdgeRepository<V1, V2>() where V1 : Vertex where V2 : Vertex
        {
            return new CosmosDBEdgeRepository<V1, V2>(_cosmosClient);
        }

        /// <summary>
        /// Get a generic Vertex Repository
        /// </summary>
        /// <typeparam name="V">The type of the vertex</typeparam>
        /// <returns>An IVertexRepository</returns>
        public IVertexRepository<V> GetVertexRepository<V>() where V : Vertex
        {
            return new CosmosDBVertexRepository<V>(_cosmosClient);
        }
    }
}