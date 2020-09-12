using System;
using System.Collections.Generic;
using FamilyTreeProject.Common;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Edges;

namespace FamilyTreeProject.Graph.Vertices
{
    /// <summary>
    /// Represents an Individual
    /// </summary>
    public class Individual : CitationsVertexBase
    {
        /// <summary>
        /// Constructs an Individual
        /// </summary>
        public Individual() : this(String.Empty, String.Empty)
        {
            Born = String.Empty;
            Died = String.Empty;
            FirstName = String.Empty;
            LastName = String.Empty;
            Suffix = String.Empty;
            Title = String.Empty;
            
        }

        /// <summary>
        /// Constructs an Individual
        /// </summary>
        /// <param name="id">The Id of the Individual</param>
        /// <param name="treeId">The TreeId of the Tree which contains this individual</param>
        public Individual(string id, string treeId) : base(id, EntityType.Individual, treeId)
        {
            FirstName = String.Empty;
            LastName = String.Empty;
            Sex = Sex.Unknown;
            Children = new List<Child>();
            Parents = new List<Parent>();
            Spouses = new List<Spouse>();
            Facts = new List<Has<Fact>>();
        }

        /// <summary>
        /// Gets or Sets whether the Individual is alive
        /// </summary>
        public bool? Alive 
        {
            get
            {
                bool? value = null;
                if (Properties.ContainsKey("alive"))
                {
                    string alive = Properties["alive"];
                    if (!String.IsNullOrEmpty(alive))
                    {
                        bool boolValue = false;
                        Boolean.TryParse(alive, out boolValue);
                        value = boolValue;
                    }
                }
                return value;
            }
            set => Properties["alive"] = value.ToString();
        }

        /// <summary>
        ///   Gets or sets when the individual was Born
        /// </summary>
        public string Born
        {
            get => Properties["born"];
            set => Properties["born"] = value;
        }

        /// <summary>
        ///   Gets or sets when the individual Died
        /// </summary>
        public string Died
        {
            get => Properties["died"];
            set => Properties["died"] = value;
        }

        /// <summary>
        ///   Gets or sets the first name of the individual
        /// </summary>
        public string FirstName
        {
            get => Properties["firstName"];
            set
            {
                Properties["firstName"] = value;
                UpdateName();
            }
        }

        /// <summary>
        ///   Gets or sets the last name of the individual
        /// </summary>
        public string LastName
        {
            get => Properties["lastName"];
            set
            {
                Properties["lastName"] = value;
                UpdateName();
            }
        }

        /// <summary>
        /// Gets the name of this Individual
        /// </summary>
        public string Name => Properties["name"];

        /// <summary>
        ///   Gets or sets the Sex of this individual
        /// </summary>
        public Sex Sex 
        {
            get => (Sex) Enum.Parse(typeof(Sex), Properties["sex"]);
            set => Properties["sex"] = value.ToString();
        }
        
        /// <summary>
        ///   Gets or sets the Suffix of the individual
        /// </summary>
        public string Suffix
        {
            get => Properties["suffix"];
            set
            {
                Properties["suffix"] = value;
                UpdateName();
            }
        }

        /// <summary>
        ///   Gets or sets the Title of the individual
        /// </summary>
        public string Title
        {
            get => Properties["title"];
            set => Properties["title"] = value;
        }


        //Edge Properties

        /// <summary>
        /// Gets the collection of Children
        /// </summary>
        public IList<Child> Children { get; }
        
        /// <summary>
        /// Gets a collection of Facts for this Individual
        /// </summary>
        public IList<Has<Fact>> Facts { get; }

        /// <summary>
        /// Gets the collection of Parents
        /// </summary>
        public IList<Parent> Parents { get; }

        /// <summary>
        /// Gets the collection of Spouses
        /// </summary>
        public IList<Spouse> Spouses { get; }

        public void AddChild(Individual child)
        {
            Children.Add(new Child(this, child));
            
            child.Parents.Add(new Parent(child, this, GetParentType(Sex)));
        }

        public void AddParent(Individual parent)
        {
            Parents.Add(new Parent(this, parent, GetParentType(parent.Sex)));
            
            parent.Children.Add(new Child(parent, this));
        }
        
        /// <summary>
        /// Adds a new Fact to the Facts collection
        /// </summary>
        /// <param name="newCitation">The new Fact to add</param>
        public void AddFact(Fact newFact)
        {
            Facts.Add(new Has<Fact>(this, newFact));
        }

        public void AddSpouse(Individual spouse)
        {
            Spouses.Add(new Spouse(this, spouse));
            spouse.Spouses.Add(new Spouse(spouse, this));
        }

        private ParentType GetParentType(Sex sex)
        {
            var parentType = (sex == Sex.Male)
                ? ParentType.Father
                : (sex == Sex.Female)
                    ? ParentType.Mother
                    : ParentType.Unknown;
            return parentType;
        }

        private void UpdateName()
        {
            string lastName = String.Empty;
            Properties.TryGetValue("lastName", out lastName);
            
            string firstName = String.Empty;
            Properties.TryGetValue("firstName", out firstName);
            
            string suffix = String.Empty;
            Properties.TryGetValue("suffix", out suffix);
            
            Properties["name"] = $"{lastName}, {firstName}{suffix}";
        }
    }
}