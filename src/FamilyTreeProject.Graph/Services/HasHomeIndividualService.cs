using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Edges;
using FamilyTreeProject.Graph.Services.Interfaces;

namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// The HasHomeIndividualService contains methods to manage HasHomeIndividual edge objects
    /// </summary>
    public class HasHomeIndividualService: FamilyTreeEdgeServiceBase<HasHomeIndividual>, IHasHomeIndividualService
    {
        /// <summary>
        /// Construct a HasHomeIndividualService
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        public HasHomeIndividualService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// Adds a HasHomeIndividual edge to the data store
        /// </summary>
        /// <param name="hasHomeIndividual">The HasHomeIndividual edge to add</param>
        public void Add(HasHomeIndividual hasHomeIndividual)
        {
            AddInternal(hasHomeIndividual);
        }
    }
}