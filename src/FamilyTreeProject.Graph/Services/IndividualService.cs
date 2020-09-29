using System;
using System.Collections.Generic;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Services.Interfaces;
using FamilyTreeProject.Graph.Vertices;
using Microsoft.Extensions.Caching.Memory;
using Naif.Core.Collections;
using Naif.Core.Contracts;

namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// The IndividualService contains methods to manage individual objects
    /// </summary>
    public class IndividualService : CitationsVertexServiceBase<Individual>, IIndividualService
    {
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IFactService _factService;
        private readonly IHasService<Fact> _hasFactService;
        private readonly INoteService _noteService;

        private readonly IIndividualRepository _individualRepository;
        
        /// <summary>
        /// Constructs an IndividualService
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        /// <param name="serviceFactory">The service factory to use to create services</param>
        public IndividualService(IMemoryCache memoryCache, IUnitOfWork unitOfWork, IFamilyTreeServiceFactory serviceFactory) : base(unitOfWork, serviceFactory)
        {
            Requires.NotNull(memoryCache);

            _cache = memoryCache;
            _unitOfWork = unitOfWork;
            _factService = serviceFactory.CreateFactService();
            _hasFactService = serviceFactory.CreateHasFactService();
            _noteService = serviceFactory.CreateNoteService();
            _individualRepository = _unitOfWork.GetRepository<IIndividualRepository>();
        }

        /// <summary>
        /// Adds an Individual to the data store
        /// </summary>
        /// <param name="individual">The individual to add</param>
        /// <param name="tree">The tree we are working with</param>
        /// <param name="addEdges">A flag that determines whether the edges are added</param>
        public void Add(Individual individual, Tree tree, bool addEdges)
        {
            AddInternal(individual, tree, addEdges);
            if (addEdges)
            {
                foreach (var hasFact in individual.Facts)
                {
                    var fact = (Fact)hasFact.TargetVertex;

                    _factService.Add(fact, tree, addEdges);
                    _hasFactService.Add(hasFact);
                }
            }

            _unitOfWork.Commit();
        }

        /// <summary>
        /// Gets a list of Individuals
        /// </summary>
        /// <param name="treeId">The Id of the tree which contains the indivduals</param>
        /// <param name="pageIndex">The page Index</param>
        /// <param name="pageSize">The page size</param>
        /// <param name="includeFacts">A flag that determines whether an individual's facts should be returned</param>
        /// <param name="includeNotes">A flag that determines whether an individual's notes should be returned</param>
        /// <returns>An IEnumerable of Individuals</returns>
        public IPagedList<Individual> Get(string treeId, int pageIndex, int pageSize, bool includeFacts, bool includeNotes)
        {
            var individualCache = _cache.GetOrCreate<IEnumerable<Individual>>(CacheKeys.Individuals, entry =>
            {
                var individuals = _individualRepository.Get(treeId, 0, -1);

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

                entry.SetSlidingExpiration(TimeSpan.FromSeconds(20));
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(120);

                return individuals;
            });

            return individualCache.ToPagedList(pageIndex, pageSize);
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
            foreach (var fact in _factService.Get(individual.Id))
            {
                individual.AddFact(fact);
            }
            
        }

        private void GetNotes(Individual individual)
        {
            foreach (var note in _noteService.Get(individual.Id))
            {
                individual.AddNote(note);
            }
        }
    }
}