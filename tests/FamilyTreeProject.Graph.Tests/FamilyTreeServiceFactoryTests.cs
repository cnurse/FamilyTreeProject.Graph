using System;
using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Services;
using FamilyTreeProject.Graph.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using NUnit.Framework;

namespace FamilyTreeProject.Graph.Tests
{
    [TestFixture]
    public class FamilyTreeServiceFactoryTests
    {
        [Test]
        public void FamilyTreeServiceFactory_Constructor_Throws_On_Null_IMemoryCache()
        {
            //Arrange
            IMock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            
            //Act, Assert
            Assert.Throws<ArgumentNullException>(() => new FamilyTreeServiceFactory(null, mockUnitOfWork.Object));
        }
        
        [Test]
        public void FamilyTreeServiceFactory_Constructor_Throws_On_Null_IUnitOfWork()
        {
            //Arrange
            IMock<IMemoryCache> mockMemoryCache = new Mock<IMemoryCache>();
            
            //Act, Assert
            Assert.Throws<ArgumentNullException>(() => new FamilyTreeServiceFactory(mockMemoryCache.Object, null));
        }

        [Test]
        public void FamilyTreeServiceFactory_CreateIndividualService_Returns_IndividualService()
        {
            //Arrange
            IMock<IMemoryCache> mockMemoryCache = new Mock<IMemoryCache>();
            IMock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            var familyTreeServiceFactory = new FamilyTreeServiceFactory(mockMemoryCache.Object, mockUnitOfWork.Object);
            
            //Act
            var individualService = familyTreeServiceFactory.CreateIndividualService();
            
            //Assert
            Assert.IsNotNull(individualService);
            Assert.IsInstanceOf<IIndividualService>(individualService);
            
        }

    }
}