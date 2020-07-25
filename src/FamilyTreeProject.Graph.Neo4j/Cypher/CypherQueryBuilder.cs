using System.Collections.Generic;
using System.Text;
using FamilyTreeProject.Graph.Common;

namespace FamilyTreeProject.Graph.Neo4j.Cypher
{
    public class CypherQueryBuilder
    {
        private readonly StringBuilder _sb;
        private readonly string[] _variables = {"a", "b", "c", "d", "e"};
        
        public CypherQueryBuilder()
        {
            _sb = new StringBuilder();
        }

        public void CreateNode(Element element, bool includeProperties)
        {
            _sb.Append($"CREATE (n:{element.Label}");
            AddProperties(element);
            _sb.Append(")");
        }

        public void CreateRelationship(Element element, bool includeProperties)
        {
            _sb.Append($"CREATE (a)-[r:{element.Label} ");
            AddProperties(element);
            _sb.Append("]->(b)");
        }

        public void MatchNodes(params Element[] elements)
        {
            _sb.Append("MATCH ");
            for (int i = 0; i < elements.Length; i++)
            {
                _sb.Append($"({_variables[i]}:{elements[i].Label})");
                if (i < elements.Length - 1)
                {
                    _sb.Append(", ");
                }
            }
        }

        public void Where(params Element[] elements)
        {
            _sb.Append("WHERE ");
            for (int i = 0; i < elements.Length; i++)
            {
                _sb.Append($"{_variables[i]}.id = '{elements[i].Id}'");
                if (i < elements.Length - 1)
                {
                    _sb.Append(" AND ");
                }
            }

        }

        public void And()
        {
            
        }

        public override string ToString()
        {
            return _sb.ToString();
        }

        private void AddProperties(Element element)
        {
            var properties = element.Properties;
            _sb.Append(" {");
            
            //Add Id
            _sb.Append($"id:'{element.Id}'");
            if (properties.Count > 0)
            {
                _sb.Append(", ");
            }
            
            //Add properties
            int i = 0;
            foreach(var property in properties)
            {
                i = i + 1;
                _sb.Append($"{property.Key}:'{property.Value}'");
                if (i < properties.Count)
                {
                    _sb.Append(", ");
                }
            }
            _sb.Append("}");
        }
    }
}