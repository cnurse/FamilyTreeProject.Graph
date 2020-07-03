using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using FamilyTreeProject.GEDCOM;
using FamilyTreeProject.GEDCOM.Records;
using FamilyTreeProject.GEDCOM.Structures;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Contracts;
using FamilyTreeProject.Graph.Edges;
using FamilyTreeProject.Graph.Services;
using FamilyTreeProject.Graph.Vertices;

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
                    Sex = (Sex) Enum.Parse(typeof(Sex), individualRecord.Sex.ToString()),
                };

                //ProcessFacts(individual, individualRecord.Events);

                //ProcessMultimedia(individual, individualRecord.Multimedia);

                LoadNotes(individual, individualRecord.Notes);

                //ProcessCitations(individual, individualRecord.SourceCitations);

                _individuals.Add(GEDCOMId,individual);
            }
        }
        
        private void LoadNote(FamilyTreeVertexBase vertex, string noteText)
        {
            if (!String.IsNullOrEmpty(noteText))
            {
                var newNote = new Note
                {
                    Text = noteText,
                };
                vertex.Notes.Add(new Has<Note>(vertex, newNote));
            }
        }

        private void LoadNotes(FamilyTreeVertexBase vertex, List<GEDCOMNoteStructure> notes)
        {
            foreach (var noteStructure in notes)
            {
                if (String.IsNullOrEmpty(noteStructure.XRefId))
                {
                    LoadNote(vertex, noteStructure.Text);
                }
                else
                {
                    if (_gedComDocument.NoteRecords[noteStructure.XRefId] is GEDCOMNoteRecord noteRecord && !String.IsNullOrEmpty(noteRecord.Data))
                    {

                        LoadNote(vertex, noteRecord.Data);
                    }
                }
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
                    source.Repository = new Found_In(source, repository);
                    repository.Sources.Add(new Has<Source>(repository, source));
                }

                LoadNotes(source, sourceRecord.Notes);

                _sources.Add(GEDCOMId, source);
            }
        }

        private void ProcessIndividuals(IDictionary<string, Individual> individuals, Tree tree)
        {
            
        }

        private void ProcessNotes(FamilyTreeVertexBase vertex, Tree tree)
        {
            //Add TreeId to each note
            foreach (var note in vertex.Notes)
            {
                note.TargetVertex.TreeId = tree.TreeId;
            }
        }

        private void ProcessRepositories(IDictionary<string, Repository> repositories, Tree tree)
        {
            var repositoryService = _serviceFactory.CreateRepositoryService();

            foreach (var repository in repositories.Values)
            {
                repository.TreeId = tree.TreeId;
                
                ProcessNotes(repository, tree);

                repositoryService.Add(repository, tree, true);
            }
        }

        private void ProcessSources(IDictionary<string, Source> sources, Tree tree)
        {
            var sourceService = _serviceFactory.CreateSourceService();

            foreach (var source in sources.Values)
            {
                source.TreeId = tree.TreeId;
                
                ProcessNotes(source, tree);

                sourceService.Add(source, tree, true);
            }

        }

    }
}