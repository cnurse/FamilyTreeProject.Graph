using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Edges;
using FamilyTreeProject.Graph.Services.Interfaces;

namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// The HasService contains methods to manage Has edge objects
    /// </summary>
    public class HasService<V> : FamilyTreeEdgeServiceBase<Has<V>>, IHasService<V> where V : FamilyTreeVertexBase
    {
        /// <summary>
        /// Creates a HasService
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        public HasService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// Adds a Has<V> edge to the data store
        /// </summary>
        /// <param name="has">The Has<V> edge to add</param>
        public void Add(Has<V> has)
        {
            AddInternal(has);
        }
    }
}