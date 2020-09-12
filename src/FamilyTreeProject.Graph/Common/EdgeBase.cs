namespace FamilyTreeProject.Graph.Common
{
    public abstract class EdgeBase : Element
    {
        protected EdgeBase(string id, EdgeType edgeType, Vertex source, Vertex target) : base(id, edgeType.ToString())
        {
            EdgeType = edgeType;
            SourceVertex = source;
            TargetVertex = target;
        }
        
        /// <summary>
        /// Gets the EdgeType of the Edge
        /// </summary>
        public EdgeType EdgeType { get; }
        
        /// <summary>
        /// Gets the Source Vertex
        /// </summary>
        public Vertex SourceVertex { get; }
    
        /// <summary>
        /// Gets the Target Vertex
        /// </summary>
        public Vertex TargetVertex { get; }

    }
}