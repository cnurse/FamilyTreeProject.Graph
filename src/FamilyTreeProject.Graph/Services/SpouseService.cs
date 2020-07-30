using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Edges;
using FamilyTreeProject.Graph.Services.Interfaces;

namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// The SpouseService contains methods to manage Spouse edge objects
    /// </summary>
    public class SpouseService: FamilyTreeEdgeServiceBase<Spouse>, ISpouseService
    {
        /// <summary>
        /// Construct a SpouseService
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        public SpouseService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// Adds a Spouse edge to the data store
        /// </summary>
        /// <param name="spouse">The Spouse edge to add</param>
        public void Add(Spouse spouse)
        {
            AddInternal(spouse);
        }
    }
}