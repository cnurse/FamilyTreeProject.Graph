using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Edges;
using FamilyTreeProject.Graph.Services.Interfaces;

namespace FamilyTreeProject.Graph.Services
{
    public class FoundInService : FamilyTreeEdgeServiceBase<FoundIn>, IFoundInService
    {
        /// <summary>
        /// Constructs a FoundInService
        /// </summary>
        /// <param name="unitOfWork"></param>
        public FoundInService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        
        /// <summary>
        /// Adds a FoundIn edge to the data store
        /// </summary>
        /// <param name="foundIn">The FoundIn edge to add</param>
        public void Add(FoundIn foundIn)
        {
            AddInternal(foundIn);
        }
    }
}