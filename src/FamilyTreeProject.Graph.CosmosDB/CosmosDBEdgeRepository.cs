using CosmosDB.Net;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Contracts;
using FamilyTreeProject.Graph.CosmosDB.Mappers;
using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Edges;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.CosmosDB
{
    /// <summary>
    /// The CosmosDBEdgeRepository implements the generic IEdgeRepository for Azure CosmosDB
    /// </summary>
    /// <typeparam name="E">The type of the edge</typeparam>
    public class CosmosDBEdgeRepository<E> : IEdgeRepository<E> where E : Element
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
        public void Add(E edge)
        {
            if (edge is BelongsToTree belongsToTree)
            {
                AddEdge(edge, belongsToTree.SourceVertex, belongsToTree.TargetVertex);
            } 
            if (edge is Child child)
            {
                AddEdge(edge, child.SourceVertex, child.TargetVertex);
            } 
            if (edge is FoundIn foundIn)
            {
                AddEdge(edge, foundIn.SourceVertex, foundIn.TargetVertex);
            } 
            if (edge is Has<Citation> hasCitation)
            {
                AddEdge(edge, hasCitation.SourceVertex, hasCitation.TargetVertex);
            } 
            if (edge is Has<Fact> hasFact)
            {
                AddEdge(edge, hasFact.SourceVertex, hasFact.TargetVertex);
            } 
            if (edge is Has<Note> hasNote)
            {
                AddEdge(edge, hasNote.SourceVertex, hasNote.TargetVertex);
            } 
            if (edge is Parent parent)
            {
                AddEdge(edge, parent.SourceVertex, parent.TargetVertex);
            } 
            if (edge is ReferencedIn referencedIn)
            {
                AddEdge(edge, referencedIn.SourceVertex, referencedIn.TargetVertex);
            } 
            if (edge is Spouse spouse)
            {
                AddEdge(edge, spouse.SourceVertex, spouse.TargetVertex);
            } 
            if (edge is TreeContains<Individual> treeContainsIndividual)
            {
                AddEdge(edge, treeContainsIndividual.SourceVertex, treeContainsIndividual.TargetVertex);
            } 
            if (edge is TreeContains<Source> treeContainsSource)
            {
                AddEdge(edge, treeContainsSource.SourceVertex, treeContainsSource.TargetVertex);
            } 
            if (edge is TreeContains<Repository> treeContainsRepository)
            {
                AddEdge(edge, treeContainsRepository.SourceVertex, treeContainsRepository.TargetVertex);
            } 
        }

        private void AddEdge(Element edge, Vertex source, Vertex target)
        {
            _cosmosClient.InsertEdge(edge.ToDataModel(), source.ToDataModel(), target.ToDataModel()).Wait();
        }
    }
}