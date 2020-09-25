using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Edges;

namespace FamilyTreeProject.Graph.Services.Interfaces
{
    /// <summary>
    /// The IHasService defines the methods to manage Has edge objects
    /// </summary>
    public interface IHasService<V>  where V : FamilyTreeVertexBase
    {
        /// <summary>
        /// Adds a Has edge to the data store
        /// </summary>
        /// <param name="has">The Has edge to add</param>
        void Add(Has<V> has);
    }
}