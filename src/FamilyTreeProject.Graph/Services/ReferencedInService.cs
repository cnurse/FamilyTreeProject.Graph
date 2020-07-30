using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Edges;
using FamilyTreeProject.Graph.Services.Interfaces;

namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// The ReferencedInService contains methods to manage ReferencedIn edge objects
    /// </summary>
    public class ReferencedInService : FamilyTreeEdgeServiceBase<ReferencedIn>, IReferencedInService
    {
        /// <summary>
        /// Construct a ReferencedInService
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        public ReferencedInService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        
        /// <summary>
        /// Adds a ReferencedIn edge to the data store
        /// </summary>
        /// <param name="referencedIn">The ReferencedIn edge to add</param>
        public void Add(ReferencedIn referencedIn)
        {
            AddInternal(referencedIn);
        }
    }
}