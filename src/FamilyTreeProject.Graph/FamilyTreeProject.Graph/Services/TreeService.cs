using System;
using FamilyTreeProject.Graph.Contracts;
using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Services.Interfaces;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Services
{
    /// <summary>
    /// The TreeService contains methods to manage tree objects
    /// </summary>
    public class TreeService : ITreeService
    {
        private readonly IVertexRepository<Tree> _treeRepository;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Constructs a TreeService
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        public TreeService(IUnitOfWork unitOfWork)
        {
            Requires.NotNull(unitOfWork);

            _unitOfWork = unitOfWork;
            _treeRepository = _unitOfWork.GetVertexRepository<Tree>();
        }
        
        /// <summary>
        ///   Adds a tree to the data store and sets the <see cref = "Tree.Id" /> property
        ///   of the <paramref name = "tree" /> to the id of the new tree.
        /// </summary>
        /// <param name = "tree">The tree to add to the data store.</param>
        public void Add(Tree tree)
        {
            //Contract
            Requires.NotNull(tree);

            if (string.IsNullOrEmpty(tree.Id))
            {
                tree.Id = Guid.NewGuid().ToString();
                tree.TreeId = tree.Id;
            }
            
            _treeRepository.Add(tree);
            _unitOfWork.Commit();
        }
    }
}