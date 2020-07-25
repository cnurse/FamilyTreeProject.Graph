using CosmosDB.Net.Domain.Attributes;

namespace FamilyTreeProject.Graph.CosmosDB.DataModels
{
    /// <summary>
    /// Models the Individual vertex
    /// </summary>
    [Label(Value="Individual")]
    public class IndividualModel : BaseVertexModel
    {
        /// <summary>
        /// Gets or Sets whether the Individual is alive
        /// </summary>
        public bool Alive { get; set; }
        
        /// <summary>
        ///   Gets or sets the first name of the individual
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        ///   Gets or sets the last name of the individual
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Gets or sets the name of this Individual
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        ///   Gets or sets the Sex of this individual
        /// </summary>
        public string Sex { get; set; }
    }
}