using FamilyTreeProject.Graph.Common;

namespace FamilyTreeProject.Graph.Services.Interfaces
{
    public interface IFamilyTreeEdgeService<in E> where E : Element
    {
        /// <summary>
        /// Adds an edge to the data store
        /// </summary>
        /// <param name="edge">The edge to add</param>
        void Add(E edge);
    }
}