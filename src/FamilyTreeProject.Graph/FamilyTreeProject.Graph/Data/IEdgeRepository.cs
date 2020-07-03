using FamilyTreeProject.Graph.Common;

namespace FamilyTreeProject.Graph.Data
{
    /// <summary>
    /// Defines a simple generic repository for managing Edges
    /// </summary>
    /// <typeparam name="V1">The type of the Source Vertex</typeparam>
    /// <typeparam name="V2">The type of the Target Vertex</typeparam>
    public interface IEdgeRepository<V1, V2> where V1 : Vertex where V2: Vertex
    {
        /// <summary>
        /// Add an edge to the repository
        /// </summary>
        /// <param name="edge">The edge to be added</param>
        void Add(Edge<V1, V2> edge);
    }
}