using System.Collections.Generic;
using FamilyTreeProject.Graph.Edges;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Common
{
    /// <summary>
    /// Represents a FamilyTreeVertexBase
    /// </summary>
    public abstract class FamilyTreeVertexBase : Vertex
    {
        /// <summary>
        /// Constructs a FamilyTreeVertexBase
        /// </summary>
        /// <param name="id">The id of the FamilyTreeVertexBase</param>
        /// <param name="vertexType">The vertexType of the FamilyTreeVertexBase</param>
        /// <param name="treeId">The id of the Tree which contains this FamilyTreeVertexBase</param>
        protected FamilyTreeVertexBase(string id, VertexType vertexType, string treeId) : base(id, vertexType, treeId)
        {
            MultiMedia = new List<Has<MultiMedia>>();
            Notes = new List<Has<Note>>();
        }
               
        /// <summary>
        /// Gets the Collection of Multimedia
        /// </summary>
        public IList<Has<MultiMedia>> MultiMedia { get; }

        /// <summary>
        /// Gets a collection of Notes
        /// </summary>
        public IList<Has<Note>> Notes { get; }
    }
}