using System;
using System.Collections.Generic;
using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Services.Interfaces;
using FamilyTreeProject.Graph.Vertices;
using Naif.Core.Contracts;

namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// The NoteService contains methods to manage note objects
    /// </summary>
    public class NoteService : INoteService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INoteRepository _noteRepository;
        
        /// <summary>
        /// Constructs a NoteService
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        /// <param name="serviceFactory">The service factory to use to create services</param>
        public NoteService(IUnitOfWork unitOfWork, IFamilyTreeServiceFactory serviceFactory)
        {
            Requires.NotNull(unitOfWork);

            _unitOfWork = unitOfWork;
            _noteRepository = _unitOfWork.GetRepository<INoteRepository>();
        }

        /// <summary>
        /// Adds a Note to the data store
        /// </summary>
        /// <param name="note">The Note to add</param>
        /// <param name="tree">The tree the Note belongs to</param>
        public void Add(Note note, Tree tree)
        {
            //Contract
            Requires.NotNull(note);

            if (string.IsNullOrEmpty(note.Id))
            {
                note.Id = Guid.NewGuid().ToString();
            }
            if (string.IsNullOrEmpty(note.TreeId))
            {
                note.TreeId = tree.Id;
            }
            _noteRepository.Add(note);
            _unitOfWork.Commit();
        }

        /// <summary>
        /// Gets a list of Notes for an Individual
        /// </summary>
        /// <param name="individualId">The individual's id</param>
        /// <returns>An IEnumerable of Notes</returns>
        public IEnumerable<Note> Get(string individualId)
        {
            return _noteRepository.Get(individualId);
        }
    }
}