namespace FamilyTreeProject.Graph.Common
{
    /// <summary>
    /// An enumeration of the different Edge Types
    /// </summary>
    public enum EdgeType
    {
        None = 0,
        Contains = 1,
        Belongs_To_Tree = 2,
        Found_In = 3,
        Has = 4,
        Referenced_In = 5,
        Has_Home_Individual = 6,
        Parent = 10,
        Child = 11,
        Spouse = 12
    }
}