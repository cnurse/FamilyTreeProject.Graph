
using System.Collections.Generic;
using CosmosDB.Net.Domain.Attributes;

namespace FamilyTreeProject.Graph.Common
{
    /// <summary>
    /// The base class Vertex, is a base class for Vertices, and includes common properties  and fields
    /// It extends the base class Element.
    /// </summary>
    public abstract class Vertex : Element, IVertex
    {
        /// <summary>
        /// Constructs a Vertex.
        /// </summary>
        /// <param name="id">The Id of the Vertex</param>
        /// <param name="vertexType">The Type of Vertex being created </param>
        /// <param name="treeId">The Id of the parent Tree</param>
        protected Vertex(string id, VertexType vertexType, string treeId): base(id, vertexType.ToString())
        {
            TreeId = treeId;
            VertexType = vertexType;
        }

        
        /// <summary>
        /// Gets and sets the Id of the parent Tree (the treeId field is important for Cosmos DB as it is used as
        /// the partitionKey to ensure all components of a Tree are stored in the same partition
        /// </summary>
        public string TreeId 
        {
            get => Properties["treeId"];
            set => Properties["treeId"] = value;
        }
        
        /// <summary>
        /// Gets the VertexType of the Vertex
        /// </summary>
        public VertexType VertexType { get; }
    }
}