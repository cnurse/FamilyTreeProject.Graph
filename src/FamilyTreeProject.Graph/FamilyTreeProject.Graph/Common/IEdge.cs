namespace FamilyTreeProject.Graph.Common
{
    public interface IEdge<TV1, TV2> where TV1 : Vertex where TV2 : Vertex
    {
        /// <summary>
        /// Gets the EdgeType of the Edge
        /// </summary>
        EdgeType EdgeType { get; }

        /// <summary>
        /// Gets the Source Vertex
        /// </summary>
        TV1 SourceVertex { get; }

        /// <summary>
        /// Gets the Target Vertex
        /// </summary>
        TV2 TargetVertex { get; }
    }
}