using System;
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
        private readonly Tree _tree;
        
        /// <summary>
        /// Constructs a NoteService
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        /// <param name="serviceFactory">The service factory to use to create services</param>
        /// <param name="tree">The tree we are working with</param>
        public NoteService(IUnitOfWork unitOfWork, IFamilyTreeServiceFactory serviceFactory, Tree tree)
        {
            Requires.NotNull(unitOfWork);

            _unitOfWork = unitOfWork;
            _noteRepository = _unitOfWork.GetRepository<INoteRepository>();
            _tree = tree;
        }

        /// <summary>
        /// Adds a Note to the data store
        /// </summary>
        /// <param name="note">The Note to add</param>
        public void Add(Note note)
        {
            //Contract
            Requires.NotNull(note);

            if (string.IsNullOrEmpty(note.Id))
            {
                note.Id = Guid.NewGuid().ToString();
            }
            if (string.IsNullOrEmpty(note.TreeId))
            {
                note.TreeId = _tree.Id;
            }
            _noteRepository.Add(note);
            _unitOfWork.Commit();
        }
    }
}