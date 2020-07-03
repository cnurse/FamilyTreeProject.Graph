using System;
using CosmosDB.Net;
using FamilyTreeProject.Graph.CosmosDB;
using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Vertices;
using Moq;
using NUnit.Framework;

namespace FamilyTreeProject.Graph.Tests.Data
{
    [TestFixture]
    public class CosmosDBUnitOfWorkTests: CosmosDBTestBase
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_Throws_On_Null_Graph_Client()
        {
            //Arrange
            CosmosClientGraph client = null;

            //Act

            //Assert
            // ReSharper disable once ExpressionIsAlwaysNull
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentNullException>(() => new CosmosDBUnitOfWork(client));
        }
        
        [Test]
        public void GetRepository_Returns_Repository()
        {
            //Arrange
            var mockClient = new Mock<ICosmosClientGraph>();
            var unitOfWork = new CosmosDBUnitOfWork(mockClient.Object);

            //Act
            var rep = unitOfWork.GetVertexRepository<Tree>();

            //Assert
            Assert.IsInstanceOf<IVertexRepository<Tree>>(rep);
        }
    }
}