using FamilyTreeProject.Graph.CosmosDB.DataModels;
using FamilyTreeProject.Graph.Edges;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.CosmosDB.Mappers
{
    /// <summary>
    /// A mapper class to convert Has edges to HasModels and vice versa
    /// </summary>
    public static class HasMapper
    {
        /// <summary>
        /// Convert a Has<Fact> to a HasModel
        /// </summary>
        /// <param name="hasFact">The Has<Fact> edge to convert</param>
        /// <returns>A HasModel</returns>
        public static HasModel ToDataModel(this Has<Fact> hasFact)
        {
            return ToDataModelInternal(hasFact.Id);
        }

        /// <summary>
        /// Convert a Has<Citation> to a HasModel
        /// </summary>
        /// <param name="hasCitation">The Has<Citation> edge to convert</param>
        /// <returns>A HasModel</returns>
        public static HasModel ToDataModel(this Has<Citation> hasCitation)
        {
            return ToDataModelInternal(hasCitation.Id);
        }

        /// <summary>
        /// Convert a Has<Note> to a HasModel
        /// </summary>
        /// <param name="hasNote">The Has<Note> edge to convert</param>
        /// <returns>A HasModel</returns>
        public static HasModel ToDataModel(this Has<Note> hasNote)
        {
            return ToDataModelInternal(hasNote.Id);
        }

        /// <summary>
        /// Convert a Has<Source> to a HasModel
        /// </summary>
        /// <param name="hasSource">The Has<Source> edge to convert</param>
        /// <returns>A HasModel</returns>
        public static HasModel ToDataModel(this Has<Source> hasSource)
        {
            return ToDataModelInternal(hasSource.Id);
        }

        private static HasModel ToDataModelInternal(string id)
        {
            return new HasModel()
            {
                Id = id
            };
            
        }
    }
}