using System;
using CosmosDB.Net;
using FamilyTreeProject.Graph.CosmosDB;
using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Importers;
using FamilyTreeProject.Graph.Services;
using FamilyTreeProject.Graph.Vertices;
using NUnit.Framework;

namespace FamilyTreeProject.Graph.Tests.Importers
{
    [TestFixture]
    public class GEDCOMImporterTests : CosmosDBTestBase
    {
        [TestCase("Test", "Test Tree", "A Test Family Tree", "me@mail.com")]
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

        private ICosmosClientGraph CreateCosmosClient()
        {
            var graphClient =  CosmosClientGraph.GetClientWithSql(CosmosDB_AccountName, CosmosDB_Key, CosmosDB_Database, CosmosDB_Container, null);

            return graphClient.Result;
        }
        
    }
};