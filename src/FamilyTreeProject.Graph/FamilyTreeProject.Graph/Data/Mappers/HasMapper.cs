using FamilyTreeProject.Graph.Data.DataModels;
using FamilyTreeProject.Graph.Edges;
using FamilyTreeProject.Graph.Vertices;

namespace FamilyTreeProject.Graph.Data.Mappers
{
    /// <summary>
    /// A mapper class to convert Has edges to HasModels and vice versa
    /// </summary>
    public static class HasMapper
    {
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