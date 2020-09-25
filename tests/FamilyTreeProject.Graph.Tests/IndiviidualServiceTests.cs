using System;
using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Services;
using FamilyTreeProject.Graph.Services.Interfaces;
using FamilyTreeProject.Graph.Vertices;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using NUnit.Framework;

namespace FamilyTreeProject.Graph.Tests
{
    [TestFixture]
    public class IndiviidualServiceTests
    {
        [Test]
        public void IndividualService_Constructor_Throws_On_Null_IMemoryCache()
        {
            //Arrange
            IMock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            IMock<IFamilyTreeServiceFactory> mockFamilyTreeServiceFactory = new Mock<IFamilyTreeServiceFactory>();
            
            //Act, Assert
            Assert.Throws<ArgumentNullException>(() => new IndividualService(null, mockUnitOfWork.Object, mockFamilyTreeServiceFactory.Object));
        }

        [Test]
        public void IndividualService_Constructor_Throws_On_Null_IUnitOfWork()
        {
            //Arrange
            IMock<IMemoryCache> mockMemoryCache = new Mock<IMemoryCache>();
            IMock<IFamilyTreeServiceFactory> mockFamilyTreeServiceFactory = new Mock<IFamilyTreeServiceFactory>();
            
            //Act, Assert
            Assert.Throws<ArgumentNullException>(() => new IndividualService(mockMemoryCache.Object, null, mockFamilyTreeServiceFactory.Object));
        }
        
        [Test]
        public void IndividualService_Constructor_Throws_On_Null_IFamilyTreeServiceFactory()
        {
            //Arrange
            IMock<IMemoryCache> mockMemoryCache = new Mock<IMemoryCache>();
            IMock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            
            //Act, Assert
            Assert.Throws<ArgumentNullException>(() => new IndividualService(mockMemoryCache.Object, mockUnitOfWork.Object, null));
        }

        [Test]
        public void IndividualService_Constructor_Calls_ServiceFactory_To_Create_Services()
        {
            //Arrange
            Mock<IMemoryCache> mockMemoryCache = new Mock<IMemoryCache>();
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            Mock<IFamilyTreeServiceFactory> mockServiceFactory = new Mock<IFamilyTreeServiceFactory>();
            
            //Act
            var individualService = new IndividualService(mockMemoryCache.Object, mockUnitOfWork.Object, mockServiceFactory.Object);
            
            //Assert
            mockServiceFactory.Verify((f) => f.CreateFactService());
            mockServiceFactory.Verify((f) => f.CreateHasFactService());
            mockServiceFactory.Verify((f) => f.CreateCitationService());
            mockServiceFactory.Verify((f) => f.CreateHasCitationService());
            mockServiceFactory.Verify((f) => f.CreateNoteService());
            mockServiceFactory.Verify((f) => f.CreateHasNoteService());
            mockServiceFactory.Verify((f) => f.CreateBelongsToTreeService());
        }

        [Test]
        public void IndividualService_Constructor_Calls_UnitOfWork_To_Create_Repositories()
        {
            //Arrange
            Mock<IMemoryCache> mockMemoryCache = new Mock<IMemoryCache>();
            Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
            Mock<IFamilyTreeServiceFactory> mockServiceFactory = new Mock<IFamilyTreeServiceFactory>();
            
            //Act
            var individualService = new IndividualService(mockMemoryCache.Object, mockUnitOfWork.Object, mockServiceFactory.Object);
            
            //Assert
            mockUnitOfWork.Verify((u) => u.GetRepository<IIndividualRepository>());
            mockUnitOfWork.Verify((u) => u.GetVertexRepository<Individual>());
        }

    }
}