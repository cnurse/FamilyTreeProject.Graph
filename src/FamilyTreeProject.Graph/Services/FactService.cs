using System.Collections.Generic;
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
        private readonly IFactRepository _factRepository;

        /// <summary>
        /// Constructs a FactService
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        /// <param name="serviceFactory">The service factory to use to create services</param>
        public FactService(IUnitOfWork unitOfWork, IFamilyTreeServiceFactory serviceFactory) : base(unitOfWork, serviceFactory)
        {
            Requires.NotNull(unitOfWork);
            
            _unitOfWork = unitOfWork;
            _factRepository = _unitOfWork.GetRepository<IFactRepository>();
        }

        /// <summary>
        /// Adds a fact to the data store
        /// </summary>
        /// <param name="fact">The fact to add</param>
        /// <param name="tree">The tree we are working with</param>
        /// <param name="addEdges">A flag that determines whether the edges are added</param>
        public void Add(Fact fact, Tree tree, bool addEdges)
        {
            AddInternal(fact, tree, addEdges, false);

            _unitOfWork.Commit();
        }

        /// <summary>
        /// Gets a list of Facts for an Individual
        /// </summary>
        /// <param name="individualId">The individual's id</param>
        /// <returns>An IEnumerable of Facts</returns>
        public IEnumerable<Fact> Get(string individualId)
        {
            return _factRepository.Get(individualId);
        }
    }
}