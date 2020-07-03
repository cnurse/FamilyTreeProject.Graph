using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// The IndividualService contains methods to manage individual objects
    /// </summary>
    public class IndividualService : FamilyTreeVertexService<Individual>, IIndividualService
    {
        /// <summary>
        /// Constructs an IndividualService
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        public IndividualService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// AddEdges is used to add the edges when the base classes Add method is called with addEdges = true
        /// </summary>
        /// <param name="individual">The individual being added</param>
        /// <param name="tree">The tree that the individual belongs to</param>
        protected override void AddEdges(Individual individual, Tree tree)
        {
            throw new System.NotImplementedException();
        }
    }
}