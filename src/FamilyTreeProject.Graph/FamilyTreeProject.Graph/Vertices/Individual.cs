using System;
using System.Collections.Generic;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Edges;

namespace FamilyTreeProject.Graph.Vertices
{
    /// <summary>
    /// Represents an Individual
    /// </summary>
    public class Individual : FamilyTreeVertexBase
    {
        /// <summary>
        /// Constructs an Individual
        /// </summary>
        public Individual() : this(String.Empty, String.Empty)
        {
        }

        /// <summary>
        /// Constructs an Individual
        /// </summary>
        /// <param name="id">The Id of the Individual</param>
        /// <param name="treeId">The TreeId of the Tree which contains this individual</param>
        public Individual(string id, string treeId) : base(id, VertexType.Individual, treeId)
        {
            FirstName = String.Empty;
            LastName = String.Empty;
            Sex = Sex.Unknown;
            Children = new List<Child>();
            Parents = new List<Parent>();
            Spouses = new List<Spouse>();
            Citations = new List<Citation>();
            Facts = new List<Has<Fact>>();
        }

        /// <summary>
        /// Gets or Sets whether the Individual is alive
        /// </summary>
        public bool? Alive { get; set; }
        
        /// <summary>
        ///   Gets or sets the first name of the individual
        /// </summary>
        public string FirstName 
        {
            get => Properties["firstName"];
            set => Properties["firstName"] = value;
        }

        /// <summary>
        ///   Gets or sets the last name of the individual
        /// </summary>
        public string LastName 
        {
            get => Properties["lastName"];
            set => Properties["lastName"] = value;
        }

        /// <summary>
        /// Gets or sets the name of this Individual
        /// </summary>
        public string Name => $"{LastName}, {FirstName}";
        
        //Edge Properties

        /// <summary>
        /// Gets the collection of Children
        /// </summary>
        public IList<Child> Children { get; }
        
        /// <summary>
        ///   Gets the Citations for the Individual
        /// </summary>
        public IList<Citation> Citations { get; }
        
        /// <summary>
        /// Gets a collection of Facts for this Individual
        /// </summary>
        public IList<Has<Fact>> Facts { get; }

        /// <summary>
        /// Gets the collection of Parents
        /// </summary>
        public IList<Parent> Parents { get; }

        /// <summary>
        ///   Gets or sets the Sex of this individual
        /// </summary>
        public Sex Sex 
        {
            get => (Sex) Enum.Parse(typeof(Sex), Properties["sex"]);
            set => Properties["sex"] = value.ToString();
        }
        
        /// <summary>
        /// Gets the collection of Spouses
        /// </summary>
        public IList<Spouse> Spouses { get; }
    }
}