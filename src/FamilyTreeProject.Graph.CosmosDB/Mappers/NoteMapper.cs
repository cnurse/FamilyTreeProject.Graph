using FamilyTreeProject.Graph.CosmosDB.DataModels;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.CosmosDB.Mappers
{
    /// <summary>
    /// A mapper class to convert Notes to NoteModels and vice versa
    /// </summary>
    public static class NoteMapper
    {
        /// <summary>
        /// Converts a Note to a NoteModel
        /// </summary>
        /// <param name="note">The Note to convert</param>
        /// <returns>A NoteModel</returns>
        public static NoteModel ToDataModel(this Note note)
        {
            return new NoteModel
            {
                Id = note.Id,
                TreeId = note.TreeId,
                Text = note.Text
            };
        }
    }
}