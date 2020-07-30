using FamilyTreeProject.Graph.Edges;

namespace FamilyTreeProject.Graph.Services.Interfaces
{
    public interface IReferencedInService
    {
        /// <summary>
        /// Adds a ReferencedIn edge to the data store
        /// </summary>
        /// <param name="referencedIn">The ReferencedIn edge to add</param>
        void Add(ReferencedIn referencedIn);
    }
}