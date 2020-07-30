using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Data;

namespace FamilyTreeProject.Graph.Services
{
    public class FamilyTreeEdgeServiceBase<E> where E : Element
    {
        private readonly IEdgeRepository<E> _edgeRepository;

        /// <summary>
        /// Construct a BelongsToTreeService
        /// </summary>
        /// <param name="unitOfWork">The Unit of Work to use to interact with the repositories</param>
        public FamilyTreeEdgeServiceBase(IUnitOfWork unitOfWork)
        {
            _edgeRepository = unitOfWork.GetEdgeRepository<E>();
        }

        /// <summary>
        /// Adds an edge to the data store
        /// </summary>
        /// <param name="edge">The edge to add</param>
        public void AddInternal(E edge)
        {
            _edgeRepository.Add(edge);
        }

    }
}