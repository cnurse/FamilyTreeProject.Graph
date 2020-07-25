using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Edges;
using FamilyTreeProject.Graph.Services.Interfaces;

namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// The ParentService contains methods to manage Parent edge objects
    /// </summary>
    public class ParentService: FamilyTreeEdgeServiceBase<Parent>, IParentService
    {
        /// <summary>
        /// Construct a ParentService
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        public ParentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// Adds a Parent edge to the data store
        /// </summary>
        /// <param name="parent">The Parent edge to add</param>
        public void Add(Parent parent)
        {
            AddInternal(parent);
        }
    }
}