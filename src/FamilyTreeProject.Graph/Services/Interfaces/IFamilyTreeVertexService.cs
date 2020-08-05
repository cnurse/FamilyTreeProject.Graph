using FamilyTreeProject.Graph.Common;

namespace FamilyTreeProject.Graph.Services.Interfaces
{
    /// <summary>
    /// Defines an interface to define methods for a Family Tree service for a FamilyTreeVertexBase
    /// </summary>
    /// <typeparam name="V">The FamilyTreeVertexBase</typeparam>
    public interface IFamilyTreeVertexService<V> where V : FamilyTreeVertexBase
    {
        /// <summary>
        /// Adds a FamilyTreeVertexBase to the data store
        /// </summary>
        /// <param name="item">The FamilyTreeVertexBase to add</param>
        /// <param name="addEdges">A flag that determines whether the edges are added</param>
        void Add(V item, bool addEdges);

        /// <summary>
        /// Gets a FamilyTreeVertexBase from the data store, based on its Id
        /// </summary>
        /// <param name="id">The Id of the FamilyTreeVertexBase to get</param>
        /// <returns>The FamilyTreeVertex Base</returns>
        V GetById(string id);
    }
}