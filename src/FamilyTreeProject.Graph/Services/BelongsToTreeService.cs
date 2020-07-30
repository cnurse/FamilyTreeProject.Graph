using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Edges;
using FamilyTreeProject.Graph.Services.Interfaces;

namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// The BelongsToTreeService contains methods to manage BelongsToTree edge objects
    /// </summary>
    public class BelongsToTreeService : FamilyTreeEdgeServiceBase<BelongsToTree>, IBelongsToTreeService
    {
        /// <summary>
        /// Construct a BelongsToTreeService
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        public BelongsToTreeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// Adds a BelongsToTree edge to the data store
        /// </summary>
        /// <param name="belongsToTree">The BelongsToTree edge to add</param>
        public void Add(BelongsToTree belongsToTree)
        {
            AddInternal(belongsToTree);
        }
    }
}