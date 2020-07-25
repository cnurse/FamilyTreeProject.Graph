using System;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.CosmosDB.DataModels;
using FamilyTreeProject.Graph.Edges;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.CosmosDB.Mappers
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

            if (element is Individual individual)
            {
                return individual.ToDataModel();
            }

            if (element is Note note)
            {
                return note.ToDataModel();
            }

            if (element is Fact fact)
            {
                return fact.ToDataModel();
            }

            if (element is Citation citation)
            {
                return citation.ToDataModel();
            }

            if (element is BelongsToTree belongsToTree)
            {
                return belongsToTree.ToDataModel();
            }

            if (element is Child child)
            {
                return child.ToDataModel();
            }

            if (element is FoundIn foundIn)
            {
                return foundIn.ToDataModel();
            }

            if (element is Has<Note> hasNote)
            {
                return hasNote.ToDataModel();
            }

            if (element is Has<Fact> hasFact)
            {
                return hasFact.ToDataModel();
            }

            if (element is Has<Citation> hasCitation)
            {
                return hasCitation.ToDataModel();
            }

            if (element is Has<Source> hasSource)
            {
                return hasSource.ToDataModel();
            }

            if (element is Parent parent)
            {
                return parent.ToDataModel();
            }

            if (element is ReferencedIn referencedIn)
            {
                return referencedIn.ToDataModel();
            }

            if (element is Spouse spouse)
            {
                return spouse.ToDataModel();
            }

            if (element is TreeContains<Repository> containsRepository)
            {
                return containsRepository.ToDataModel();
            }

            if (element is TreeContains<Source> containsSource)
            {
                return containsSource.ToDataModel();
            }

            if (element is TreeContains<Individual> containsIndividual)
            {
                return containsIndividual.ToDataModel();
            }

            throw new NotImplementedException();
        }
    }
}