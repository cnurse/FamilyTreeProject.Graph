using FamilyTreeProject.Graph.Common;

namespace FamilyTreeProject.Graph.Data
{
    /// <summary>
    /// Defines a simple generic repository for managing Edges
    /// </summary>
    /// <typeparam name="E">The type of the Edge</typeparam>
    public interface IEdgeRepository<in E> where E : Element
    {
        /// <summary>
        /// Add an edge to the repository
        /// </summary>
        /// <param name="edge">The edge to be added</param>
        void Add(E edge);
    }
}