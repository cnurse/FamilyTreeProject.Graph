using System.Text;
using FamilyTreeProject.Graph.Common;
using FamilyTreeProject.Graph.Contracts;
using FamilyTreeProject.Graph.Data;
using FamilyTreeProject.Graph.Edges;
using FamilyTreeProject.Graph.Neo4j.Cypher;
using Neo4j.Driver;

namespace FamilyTreeProject.Graph.Neo4j
{
    public class Neo4jEdgeRepository<E> : IEdgeRepository<E> where E : Element
    {
        private readonly ISession _session;

        public Neo4jEdgeRepository(ISession session)
        {
            Requires.NotNull(session);
            
            _session = session;
        }
        
        public void Add(E element)
        {
            if (element is EdgeBase edge)
            {
                var queryBuilder = new CypherQueryBuilder();
            
                //Build MATCH clause
                queryBuilder.MatchNodes(edge.SourceVertex, edge.TargetVertex);
                
                //Build WHERE clause
                queryBuilder.Where(edge.SourceVertex, edge.TargetVertex);
                
                //Build CREATE Clause
                queryBuilder.CreateRelationship(element, true);

                _session.WriteTransaction(tx =>
                {
                    return tx.Run(queryBuilder.ToString(), new { });
                });
            }
        }
    }
}