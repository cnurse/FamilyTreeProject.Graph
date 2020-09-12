using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Services.Interfaces;
using FamilyTreeProject.Graph.Vertices;
using Naif.Core.Contracts;

namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// The FactService contains methods to manage fact/event objects
    /// </summary>
    public class FactService : CitationsVertexServiceBase<Fact>, IFactService
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructs a FactService
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        public FactService(IUnitOfWork unitOfWork, IFamilyTreeServiceFactory serviceFactory, Tree tree) : base(unitOfWork, serviceFactory, tree)
        {
            Requires.NotNull(unitOfWork);
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Adds a fact to the data store
        /// </summary>
        /// <param name="fact">The fact to add</param>
        public void Add(Fact fact, bool addEdges)
        {
            AddInternal(fact, addEdges, false);

            _unitOfWork.Commit();
        }
    }
}