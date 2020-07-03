using System;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Data.DataModels;
using FamilyTreeProject.Graph.Edges;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Data.Mappers
{
    /// <summary>
    /// A base mapper class to convertElements to BaseModels and vice versa
    /// </summary>
    public static class ElementMapper
    {
        /// <summary>
        /// Convert an Element to a BaseModel
        /// </summary>
        /// <param name="element">The Element to convert</param>
        /// <returns>A BaseModel</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static BaseModel ToDataModel(this Element element)
        {
            if (element is Tree tree)
            {
                return tree.ToDataModel();
            }
            if (element is Repository repository)
            {
                return repository.ToDataModel();
            }

            if (element is Source source)
            {
                return source.ToDataModel();
            }

            if (element is Note note)
            {
                return note.ToDataModel();
            }

            if (element is BelongsToTree belongsToTree)
            {
                return belongsToTree.ToDataModel();
            }

            if (element is Found_In foundIn)
            {
                return foundIn.ToDataModel();
            }

            if (element is Has<Note> hasNote)
            {
                return hasNote.ToDataModel();
            }

            if (element is Has<Source> hasSource)
            {
                return hasSource.ToDataModel();
            }

            if (element is TreeContains<Repository> containsRepository)
            {
                return containsRepository.ToDataModel();
            }

            if (element is TreeContains<Source> containsSource)
            {
                return containsSource.ToDataModel();
            }

            throw new NotImplementedException();
        }
    }
}