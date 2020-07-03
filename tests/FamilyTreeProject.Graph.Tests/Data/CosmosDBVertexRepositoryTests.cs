using System;
using CosmosDB.Net;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.CosmosDB;
using NUnit.Framework;

namespace FamilyTreeProject.Graph.Tests.Data
{
    public abstract class CosmosDBVertexRepositoryTests<V> : CosmosDBTestBase where V : Vertex, new()
    {
        [Test]
        public void Constructor_Throws_On_Null_DocumentClient()
        {
            //Arrange
            CosmosClientGraph client = null;

            //Act

            //Assert
            // ReSharper disable once ExpressionIsAlwaysNull
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentNullException>(() => new CosmosDBVertexRepository<V>(client));
        }
    }
}