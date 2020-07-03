using CosmosDB.Net;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Contracts;
using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Data.Mappers;

namespace FamilyTreeProject.Graph.CosmosDB
{
    /// <summary>
    /// The CosmosDBEdgeRepository implements the generic IEdgeRepository for Azure CosmosDB
    /// </summary>
    /// <typeparam name="V1">The type of the source Vertex</typeparam>
    /// <typeparam name="V2">The tyep of the target Vertex</typeparam>
    public class CosmosDBEdgeRepository<V1, V2> : IEdgeRepository<V1, V2> where V1 : Vertex where V2 : Vertex
    {
        private readonly ICosmosClientGraph _cosmosClient;
        
        /// <summary>
        /// Constructs a CosmosDBEdgeRepository object
        /// </summary>
        /// <param name="cosmosClient">The CosmosClient to use</param>
        public CosmosDBEdgeRepository(ICosmosClientGraph cosmosClient)
        {
            Requires.NotNull(cosmosClient);
            
            _cosmosClient = cosmosClient;
        }
        
        /// <summary>
        /// Add an edge to the repository
        /// </summary>
        /// <param name="edge">The edge to add</param>
        public void Add(Edge<V1, V2> edge)
        {
            _cosmosClient.InsertEdge(edge.ToDataModel(), edge.SourceVertex.ToDataModel(), edge.TargetVertex.ToDataModel()).Wait();
        }
    }
}