using CosmosDB.Net;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Contracts;
using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Data.Mappers;

namespace FamilyTreeProject.Graph.CosmosDB
{
    /// <summary>
    /// The CosmosDBVertexRepository implements the generic IVertexRepository for Azure CosmosDB
    /// </summary>
    /// <typeparam name="V">The type of Vertex</typeparam>
    public class CosmosDBVertexRepository<V> : IVertexRepository<V> where V : Vertex
    {
        private readonly ICosmosClientGraph _cosmosClient;
        
        /// <summary>
        /// Constructs a CosmosDBVertexRepository object
        /// </summary>
        /// <param name="cosmosClient">The CosmosClient to use</param>
        public CosmosDBVertexRepository(ICosmosClientGraph cosmosClient)
        {
            Requires.NotNull(cosmosClient);
            
            _cosmosClient = cosmosClient;
        }

        /// <summary>
        /// Add a vertex into the repository
        /// </summary>
        /// <param name="vertex">The vertex to be added</param>
        public void Add(V vertex)
        {
            _cosmosClient.InsertVertex(vertex.ToDataModel()).Wait();
        }


    }
}