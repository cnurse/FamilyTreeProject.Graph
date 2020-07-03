using System.IO;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace FamilyTreeProject.Graph.Tests
{
    public abstract class CosmosDBTestBase
    {
        protected IConfigurationRoot _configuration;

        protected string FilePath { get; private set; }
        protected string CosmosDB_AccountName => _configuration["CosmosDB:AccountName"];
        protected string CosmosDB_Key => _configuration["CosmosDB:Key"];
        protected string CosmosDB_Database => _configuration["CosmosDB:Database"];
        protected string CosmosDB_Container => _configuration["CosmosDB:Container"];
        
        [OneTimeSetUp]
        public void Initialize()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("testsettings.json");

            var solutionDir = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory)));

           
            _configuration = builder.Build();
            
            FilePath = Path.Combine(solutionDir, _configuration["filePath"]);
        }

        protected string GetFullPath(string file)
        {
            return Path.Combine(FilePath, file);
        }
       
    }
}