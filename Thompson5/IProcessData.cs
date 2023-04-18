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
***               IProcessData will have one method in an         ***
***               interface which makes it so any class has to    ***
***               provide an implementation for the method        ***
********************************************************************/

namespace GraphNS
{
    public interface IProcessData
    {
        /********************************************************************
        *** METHOD: public abstract void ReadData(string path);           ***
        *********************************************************************
        *** DESCRIPTION : This interface is used to read data from        ***
        ***               a file. It has one abstract method called       ***
        ***               ReadData, which takes a path to a file as an    ***
        ***               input argument. Any class that implements this  ***
        ***               interface must provide an implementation        ***
        ****              for this method                                 ***
        *** INPUT ARGS : string path - the path to the file to be read    ***
        *** OUTPUT ARGS : n/a                                             ***
        *** IN/OUT ARGS : n/a                                             ***
        *** RETURN : n/a                                                  ***
        ********************************************************************/
        public abstract void ReadData(string path);
    }
}
