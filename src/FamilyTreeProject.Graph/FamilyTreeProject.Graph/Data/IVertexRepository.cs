using FamilyTreeProject.Graph.Common;

namespace FamilyTreeProject.Graph.Data
{
    /// <summary>
    /// Defines a simple generic repository for managing vertices
    /// </summary>
    /// <typeparam name="V">The vertex type</typeparam>
    public interface IVertexRepository<V> where V : Vertex
    {
        /// <summary>
        /// Add a vertex into the repository
        /// </summary>
        /// <param name="vertex">The vertex to be added</param>
        void Add(V vertex);
    }
}