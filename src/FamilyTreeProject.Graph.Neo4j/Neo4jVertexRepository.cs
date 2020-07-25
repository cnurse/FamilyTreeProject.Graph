using System.Linq;
using System.Text;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Contracts;
using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Neo4j.Cypher;
using FamilyTreeProject.Graph.Vertices;
using Neo4j.Driver;

namespace FamilyTreeProject.Graph.Neo4j
{
    public class Neo4jVertexRepository<V> : IVertexRepository<V> where V : Vertex
    {        
        private readonly ISession _session;
        
        public Neo4jVertexRepository(ISession session)
        {
            Requires.NotNull(session);
            
            _session = session;
        }
        
        public void Add(V vertex)
        {
            var queryBuilder = new CypherQueryBuilder();
            
            //Build CREATE Clause
            queryBuilder.CreateNode(vertex, true);

            _session.WriteTransaction(tx =>
            {
                return tx.Run(queryBuilder.ToString(), new { });
            });
            
        }
    }
}