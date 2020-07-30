
using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Edges;
using FamilyTreeProject.Graph.Services.Interfaces;

namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// The ChildService contains methods to manage Child edge objects
    /// </summary>
    public class ChildService : FamilyTreeEdgeServiceBase<Child>, IChildService
    {
        /// <summary>
        /// Construct a ChildService
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        public ChildService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// Adds a Child edge to the data store
        /// </summary>
        /// <param name="child">The Child edge to add</param>
        public void Add(Child child)
        {
            AddInternal(child);
        }
    }
}