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
***               ISearchAlgorithm will have two methods in       ***
***               an interface which makes it so any class has    ***
***               to provide an implementation for the two methods***
***               It also has two properties Queue & Stack        ***
********************************************************************/

namespace GraphNS
{
    public interface ISearchAlgorithms
    {
        //PROPERTIES
        public Queue<Node> Queue { get {return Queue;} set{Queue = value;}}
        public Stack<Node> Stack { get{return Stack;} set{Stack = value;} }

        /********************************************************************
        *** METHOD: public abstract void BreadthFS(int start);            ***
        *********************************************************************
        *** DESCRIPTION :  Performs a breadth-first search on a           ***
        ***                graph starting at the specified node.Uses a    ***
        ***                queue data structure to store nodes to be      ***
        ***                visited next. Any class that implements the    ***
        ***                ISearchAlgorithms interface must provide an    ***
        ***                implementation for this method.                ***
        *** INPUT ARGS : int start  - node to start search from           ***
        *** OUTPUT ARGS : n/a                                             ***
        *** IN/OUT ARGS : n/a                                             ***
        *** RETURN : n/a                                                  ***
        ********************************************************************/  
        public abstract void BreadthFS(int start);


        /********************************************************************
        *** METHOD: public abstract void DepthFS(int start);              ***
        *********************************************************************
        *** DESCRIPTION :  Performs a depth-first search on a graph       ***
        ***                starting at the specified node. Uses a stack   ***
        ***                data structure to store nodes to be visited    ***
        ***                next. Any class that implements the            ***
        ***                ISearchAlgorithms interface must provide an    ***
        ***                implementation for this method.                ***
        *** INPUT ARGS : int start  - node to start search from           ***
        *** OUTPUT ARGS : n/a                                             ***
        *** IN/OUT ARGS : n/a                                             ***
        *** RETURN : n/a                                                  ***
        ********************************************************************/         
        public abstract void DepthFS(int start);
    }
}
