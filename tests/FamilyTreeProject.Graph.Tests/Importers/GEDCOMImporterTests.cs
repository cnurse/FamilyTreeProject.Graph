using System;
using CosmosDB.Net;
using FamilyTreeProject.Graph.CosmosDB;
using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Importers;
using FamilyTreeProject.Graph.Neo4j;
using FamilyTreeProject.Graph.Services;
using FamilyTreeProject.Graph.Services.Interfaces;
using FamilyTreeProject.Graph.Vertices;
using Neo4j.Driver;
using NUnit.Framework;

namespace FamilyTreeProject.Graph.Tests.Importers
{
    [TestFixture]
    public class GEDCOMImporterTests : CosmosDBTestBase
    {
        [TestCase("Nurse_3", "Nurse_3 Tree", "Nurse_3 Family Tree", "me@mail.com")]
        public void Convert_GEDCOM_To_CosmosDB(string name, string title, string description, string owner)
        {
            //Arrange
            IUnitOfWork unitOfWork = new CosmosDBUnitOfWork(CreateCosmosClient());
            IFamilyTreeServiceFactory familyTreeServiceFactory = new FamilyTreeServiceFactory(unitOfWork);

            var gedcomFilePath = GetFullPath($"{name}.ged");
            var gedcomImporterer = new GEDCOMImporter(gedcomFilePath, familyTreeServiceFactory);

            var tree = new Tree()
            {
                Name = name, 
                Description = description,
                Owner = owner,
                Title = title
            };

            //Act
            gedcomImporterer.Import(tree);
        
            unitOfWork.Commit();
        }

        [TestCase("Nurse_3", "Nurse_3 Tree", "Nurse_3 Family Tree", "me@mail.com")]
        public void Convert_GEDCOM_To_Neo4j(string name, string title, string description, string owner)
        {
            //Arrange
            IUnitOfWork unitOfWork = new Neo4jUnitofWork(CreateNeo4jDriver());
            IFamilyTreeServiceFactory familyTreeServiceFactory = new FamilyTreeServiceFactory(unitOfWork);

            var gedcomFilePath = GetFullPath($"{name}.ged");
            var gedcomImporterer = new GEDCOMImporter(gedcomFilePath, familyTreeServiceFactory);

            var tree = new Tree()
            {
                Name = name, 
                Description = description,
                Owner = owner,
                Title = title
            };

            //Act
            gedcomImporterer.Import(tree);
        
            unitOfWork.Commit();
        }

        private IDriver CreateNeo4jDriver()
        {
             var uri = new Uri("neo4j://localhost:7687/"); 
            
            return GraphDatabase.Driver(uri, AuthTokens.Basic("neo4j", "75kellaway"));
        }

        private ICosmosClientGraph CreateCosmosClient()
        {
            var graphClient =  CosmosClientGraph.GetClientWithSql(CosmosDB_AccountName, CosmosDB_Key, CosmosDB_Database, CosmosDB_Container, null);

            return graphClient.Result;
        }
        
    }
};