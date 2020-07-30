namespace FamilyTreeProject.Graph.Common
{
    public interface IVertex
    {
        /// <summary>
        /// Gets and sets the Id of the parent Tree (the treeId field is important for Cosmos DB as it is used as
        /// the partitionKey to ensure all components of a Tree are stored in the same partition
        /// </summary>
        string TreeId { get; set; }

        /// <summary>
        /// Gets the VertexType of the Vertex
        /// </summary>
        VertexType VertexType { get; }
    }
}