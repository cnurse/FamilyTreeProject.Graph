using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Edges;
using FamilyTreeProject.Graph.Services.Interfaces;

namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// The TreeContainsService contains methods to manage TreeContains edge objects
    /// </summary>
    public class TreeContainsService<V> : FamilyTreeEdgeServiceBase<TreeContains<V>>, ITreeContainsService<V> where V : FamilyTreeVertexBase
    {
       
        /// <summary>
        /// Constructs a TreeContains Service
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        public TreeContainsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        
        /// <summary>
        /// Adds a TreeContains edge to the data store
        /// </summary>
        /// <param name="treeContains">The TreeContains edge to add</param>
        public void Add(TreeContains<V> treeContains)
        {
            AddInternal(treeContains);
        }
    }
}