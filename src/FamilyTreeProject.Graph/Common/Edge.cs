namespace FamilyTreeProject.Graph.Common
{
    /// <summary>
    /// The base class Edge, is a base class for Edges, and includes common properties  and fields
    /// It extends the base class Element.
    /// </summary>
    /// <typeparam name="TV1">The Type of Source Vertex</typeparam>
    /// <typeparam name="TV2">The Type of Target Vertex</typeparam>
    public abstract class Edge<TV1, TV2> : EdgeBase where TV1 : Vertex where TV2 : Vertex 
    {
        /// <summary>
        /// Constructs an Edge
        /// </summary>
        /// <param name="id">The Id of the Edge</param>
        /// <param name="edgeType">The Type of this Edge</param>
        /// <param name="source">The source Vertex</param>
        /// <param name="target">The target Vertex</param>
        protected Edge(string id, EdgeType edgeType, TV1 source, TV2 target): base(id, edgeType, source, target)
        {
        }
    }
}