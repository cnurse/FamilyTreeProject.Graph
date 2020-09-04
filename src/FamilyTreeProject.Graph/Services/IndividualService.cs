using System.Collections.Generic;
using FamilyTreeProject.Graph.Contracts;
using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Services.Interfaces;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// The IndividualService contains methods to manage individual objects
    /// </summary>
    public class IndividualService : CitationsVertexServiceBase<Individual>, IIndividualService
    {        
        private readonly IUnitOfWork _unitOfWork;

        private readonly IFactService _factService;
        private readonly IHasService<Fact> _hasFactService;

        private readonly IIndividualRepository _individualRepository;
        private readonly IFactRepository _factRepository;
        private readonly INoteRepository _noteRepository;
        
        /// <summary>
        /// Constructs an IndividualService
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        /// <param name="serviceFactory">The service factory to use to create services</param>
        /// <param name="tree">The tree we are working with</param>
        public IndividualService(IUnitOfWork unitOfWork, IFamilyTreeServiceFactory serviceFactory, Tree tree) : base(unitOfWork, serviceFactory, tree)
        {
            Requires.NotNull(unitOfWork);
            
            _unitOfWork = unitOfWork;
            _factService = serviceFactory.CreateFactService(tree);
            _hasFactService = serviceFactory.CreateHasFactService();
            _individualRepository = _unitOfWork.GetRepository<IIndividualRepository>();
            _factRepository = _unitOfWork.GetRepository<IFactRepository>();
            _noteRepository = _unitOfWork.GetRepository<INoteRepository>();
        }

        /// <summary>
        /// Adds an Individual to the data store
        /// </summary>
        /// <param name="individual">The individual to add</param>
        /// <param name="addEdges">A flag that determines whether the edges are added</param>
        public void Add(Individual individual, bool addEdges)
        {
            AddInternal(individual, addEdges);
            if (addEdges)
            {
                foreach (var hasFact in individual.Facts)
                {
                    var fact = (Fact)hasFact.TargetVertex;

                    _factService.Add(fact, addEdges);
                    _hasFactService.Add(hasFact);
                }
            }

            _unitOfWork.Commit();
        }

        /// <summary>
        /// Gets a list of Individuals
        /// </summary>
        /// <param name="pageIndex">The page Index</param>
        /// <param name="pageSize">The page size</param>
        /// <returns>An IEnumerable of Individuals</returns>
        public IEnumerable<Individual> Get(int pageIndex, int pageSize, bool includeFacts, bool includeNotes)
        {
            var individuals = _individualRepository.Get(pageIndex, pageSize);

            foreach (var individual in individuals)
            {
                if (includeFacts)
                {
                    GetFacts(individual);
                }

                if (includeNotes)
                {
                    GetNotes(individual);
                }
            }

            return individuals;
        }

        /// <summary>
        /// Gets an individual by Id
        /// </summary>
        /// <param name="id">The individual's id</param>
        /// <returns>An Individual</returns>
        public Individual GetById(string id, bool includeFacts, bool includeNotes)
        {
            var individual = _individualRepository.GetById(id);

            if (includeFacts)
            {
                GetFacts(individual);
            }

            if (includeNotes)
            {
                GetNotes(individual);
            }

            return individual;
        }

        private void GetFacts(Individual individual)
        {
            foreach (var fact in _factRepository.Get(individual.Id))
            {
                individual.AddFact(fact);
            }
            
        }

        private void GetNotes(Individual individual)
        {
            foreach (var note in _noteRepository.Get(individual.Id))
            {
                individual.AddNote(note);
            }
        }
    }
}