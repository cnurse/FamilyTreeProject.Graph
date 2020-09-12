using System.Collections.Generic;
using FamilyTreeProject.Common.Data;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Data
{
    public interface INoteRepository : IRepository, IVertexRepository<Note>
    {
        /// <summary>
        /// Gets a list of Notes for an Individual
        /// </summary>
        /// <param name="id">The individual's id</param>
        /// <returns>An IEnumerable of Notes</returns>
        IEnumerable<Note> Get(string id);    
    }
}