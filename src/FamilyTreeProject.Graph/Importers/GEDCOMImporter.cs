using System;
using System.Collections.Generic;
using System.IO;
using FamilyTreeProject.GEDCOM;
using FamilyTreeProject.GEDCOM.Records;
using FamilyTreeProject.GEDCOM.Structures;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Contracts;
using FamilyTreeProject.Graph.Edges;
using FamilyTreeProject.Graph.Services.Interfaces;
using FamilyTreeProject.Graph.Vertices;
using EventClass = FamilyTreeProject.GEDCOM.Common.EventClass;

namespace FamilyTreeProject.Graph.Importers
{
    /// <summary>
    /// This class is used to import (read) GEDCOM data and save the data in a FamilyTree Data store
    /// </summary>
    public class GEDCOMImporter
    {        
        private readonly string _path;
        private readonly GEDCOMDocument _gedComDocument;
        private readonly IFamilyTreeServiceFactory _serviceFactory;
        
        private IDictionary<string, Individual> _individuals = new Dictionary<string, Individual>();
        private readonly IDictionary<string, Repository> _repositories = new Dictionary<string, Repository>();
        private IDictionary<string, Source> _sources = new Dictionary<string, Source>();

        /// <summary>
        /// Constructs a GEDCOMImporter
        /// </summary>
        /// <param name="path">The path to the GEDCOM file to be imported</param>
        /// <param name="serviceFactory">A FamilyTreeServiceFactory to be used to generate Service classes to mange the data store</param>
        public GEDCOMImporter(string path, IFamilyTreeServiceFactory serviceFactory)
        {
            Requires.NotNullOrEmpty("path", path);

            _path = path;
            _gedComDocument = new GEDCOMDocument();
            _serviceFactory = serviceFactory;
            
            Initialize();
        }

        /// <summary>
        /// Imports the GEDCOM data into a Tree object and persists the data to the store
        /// </summary>
        /// <param name="tree"></param>
        public void Import(Tree tree)
        {
            var treeService = _serviceFactory.CreateTreeService();
            treeService.Add(tree);
            
            //Add Repositories
            ProcessRepositories(_repositories, tree);
            
            //Add Sources
            ProcessSources(_sources, tree);
            
            //Add Individuals
            ProcessIndividuals(_individuals, tree);
            
            //Add Individual Links
            ProcessFamilies(_individuals);
        }

        private void Initialize()
        {
            LoadDocument();

            LoadRepositories();
            LoadSources();
            LoadIndividuals();

            LoadFamilies();
        }
        
        private void LoadDocument()
        {
            using (var stream = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                _gedComDocument.Load(stream);
            }
        }

        private void LoadFamilies()
        {
            foreach (var gedcomRecord in _gedComDocument.FamilyRecords)
            {                
                var familyRecord = (GEDCOMFamilyRecord) gedcomRecord;
                Individual husband = null;
                Individual wife = null;
                if (!String.IsNullOrEmpty(familyRecord.Husband))
                {
                    husband = _individuals[familyRecord.Husband];
                }
                if (!String.IsNullOrEmpty(familyRecord.Wife))
                {
                    wife = _individuals[familyRecord.Wife];
                }

                if (husband != null && wife != null)
                {
                    husband.AddSpouse(wife);
                }
                
                foreach (string child in familyRecord.Children)
                {
                    var individual = _individuals[child];
                    if (individual != null)
                    {
                        husband?.AddChild(individual);
                        wife?.AddChild(individual);
                    }
                }
            }
        }
        
        private  void LoadIndividuals()
        {
            foreach (var gedcomRecord in _gedComDocument.IndividualRecords)
            {
                var individualRecord = (GEDCOMIndividualRecord) gedcomRecord;
                var GEDCOMId = individualRecord.Id;
                var individual = new Individual
                {
                    // ReSharper disable once PossibleInvalidOperationException
                    Id = Guid.NewGuid().ToString(),
                    FirstName = (individualRecord.Name != null) ? individualRecord.Name.GivenName : String.Empty,
                    LastName = (individualRecord.Name != null) ? individualRecord.Name.LastName : String.Empty,
                    Suffix = (individualRecord.Name != null) ? individualRecord.Name.Suffix : String.Empty,
                    Sex = (Sex) Enum.Parse(typeof(Sex), individualRecord.Sex.ToString()),
                };

                LoadCitations(individual, individualRecord.SourceCitations);

                LoadFacts(individual, individualRecord.Events);

                LoadMultimedia(individual, individualRecord.Multimedia);
                LoadNotes(individual, individualRecord.Notes);

                _individuals.Add(GEDCOMId,individual);
            }
        }
        
        private void LoadCitations(CitationsVertexBase vertex, List<GEDCOMSourceCitationStructure> citations)
        {
            foreach (var citationStructure in citations)
            {
                if (citationStructure == null) continue;

                var source = _sources[citationStructure.XRefId];

                var newCitation = new Citation(source)
                {
                    Date = citationStructure.Date,
                    Page = citationStructure.Page,
                    Text = citationStructure.Text,
                };
                
                LoadMultimedia(newCitation, citationStructure.Multimedia);
                LoadNotes(newCitation, citationStructure.Notes);

                vertex.AddCitation(newCitation);
            }
        }

        private void LoadFacts(Individual individual, List<GEDCOMEventStructure> events)
        {
            foreach (var eventStructure in events)
            {
                var newFact = new Fact()
                {
                    Date = eventStructure.Date,
                    Place = (eventStructure.Place != null) ? eventStructure.Place.Data : string.Empty
                };

                switch (eventStructure.EventClass)
                {
                    case EventClass.Individual:
                        newFact.FactType = (Common.FactType) Enum.Parse(typeof(Common.FactType), eventStructure.IndividualEventType.ToString());
                        break;
                    case EventClass.Family:
                        newFact.FactType = (Common.FactType) Enum.Parse(typeof(Common.FactType), eventStructure.FamilyEventType.ToString());
                        break;
                    case EventClass.Attribute:
                        newFact.FactType = (Common.FactType) Enum.Parse(typeof(Common.FactType), eventStructure.IndividualAttributeType.ToString());
                        break;
                    default:
                        newFact.FactType = Common.FactType.Unknown;
                        break;
                }

                individual.AddFact(newFact);

                LoadCitations(newFact, eventStructure.SourceCitations);

                LoadMultimedia(newFact, eventStructure.Multimedia);
                LoadNotes(newFact, eventStructure.Notes);
            }
        }

        private void LoadMultimedia(FamilyTreeVertexBase vertex, List<GEDCOMMultimediaStructure> multimedia)
        {
            
        }
        
       private void LoadNotes(FamilyTreeVertexBase vertex, List<GEDCOMNoteStructure> notes)
        {
            foreach (var noteStructure in notes)
            {
                var newNote = new Note();
                
                if (String.IsNullOrEmpty(noteStructure.XRefId))
                {
                    newNote.Text =noteStructure.Text;
                }
                else
                {
                    if (_gedComDocument.NoteRecords[noteStructure.XRefId] is GEDCOMNoteRecord noteRecord && !String.IsNullOrEmpty(noteRecord.Data))
                    {

                        newNote.Text = noteRecord.Data;
                    }
                }
                
                vertex.AddNote(newNote);
            }
        }
        
        private  void LoadRepositories()
        {
            foreach (var gedcomRecord in _gedComDocument.RepositoryRecords)
            {
                var repositoryRecord = (GEDCOMRepositoryRecord)gedcomRecord;
                var GEDCOMId = repositoryRecord.Id;
                var repository = new Repository
                {
                    // ReSharper disable once PossibleInvalidOperationException
                    Id = Guid.NewGuid().ToString(),
                    Address = repositoryRecord.Address != null ? repositoryRecord.Address.Address : "",
                    Name = repositoryRecord.Name,
                };

                LoadMultimedia(repository, repositoryRecord.Multimedia);
                LoadNotes(repository, repositoryRecord.Notes);

                _repositories.Add(GEDCOMId, repository);
            }
        }
        
        private  void LoadSources()
        {
            foreach (var gedcomRecord in _gedComDocument.SourceRecords)
            {
                var sourceRecord = (GEDCOMSourceRecord)gedcomRecord;
                var GEDCOMId = sourceRecord.Id;
                
                var source = new Source
                {
                    // ReSharper disable once PossibleInvalidOperationException
                    Id = Guid.NewGuid().ToString(),
                    Author = sourceRecord.Author,
                    Title = sourceRecord.Title,
                    Publisher = sourceRecord.PublisherInfo
                };
                
                if (sourceRecord.SourceRepository != null)
                {
                    var repository = _repositories[sourceRecord.SourceRepository.XRefId];
                    source.Repository = new FoundIn(source, repository);
                }

                LoadMultimedia(source, sourceRecord.Multimedia);
                LoadNotes(source, sourceRecord.Notes);

                _sources.Add(GEDCOMId, source);
            }
        }

        private void ProcessFamilies(IDictionary<string, Individual> individuals)
        {
            var childService = _serviceFactory.CreateChildService();
            var parentService = _serviceFactory.CreateParentService();
            var spouseService = _serviceFactory.CreateSpouseService();
            
            
            foreach (var individual in individuals.Values)
            {
                foreach (var child in individual.Children)
                {
                    childService.Add(child);
                }

                foreach (var parent in individual.Parents)
                {
                    parentService.Add(parent);
                }
                
                foreach (var spouse in individual.Spouses)
                {
                    spouseService.Add(spouse);
                }
            }
            
        }

        private void ProcessIndividuals(IDictionary<string, Individual> individuals, Tree tree)
        {
            var individualService = _serviceFactory.CreateIndividualService(tree);

            foreach (var individual in individuals.Values)
            {
                individual.TreeId = tree.TreeId;
                individualService.Add(individual, true);
            }
        }

        private void ProcessRepositories(IDictionary<string, Repository> repositories, Tree tree)
        {
            var repositoryService = _serviceFactory.CreateRepositoryService(tree);

            foreach (var repository in repositories.Values)
            {
                repository.TreeId = tree.TreeId;
                repositoryService.Add(repository, true);
            }
        }

        private void ProcessSources(IDictionary<string, Source> sources, Tree tree)
        {
            var sourceService = _serviceFactory.CreateSourceService(tree);

            foreach (var source in sources.Values)
            {
                source.TreeId = tree.TreeId;
                sourceService.Add(source, true);
            }
        }
    }
}