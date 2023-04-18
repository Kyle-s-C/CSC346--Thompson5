/********************************************************************
*** NAME : Kyle Thompson                                          ***
*** CLASS : CSc 346                                               ***
*** ASSIGNMENT : Assignment #5                                    ***
*** DUE DATE : 4-19-23                                            ***
*** INSTRUCTOR : GAMRADT                                          ***
*********************************************************************
*** DESCRIPTION : Using VS Code create a user-defnined Abstract   ***
***               Data Type using C# classes named Graph, Node    ***
***               and two interface named IProcessData &          ***
***               ISearchAlgorithm                                ***
***               Node class describes the current state of a Node***
***               class. I thas three properties, Id, WasVisitied ***
***               and AdjacentNodes                               ***
********************************************************************/


namespace GraphNS
{
    public class Node
    {
        public int Id { get; set; }
        public bool WasVisited { get; set; }
        public List<bool>? AdjacentNodes { get; set; } 
    }
}


