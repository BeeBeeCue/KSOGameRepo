using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class was originally written to implement a pathfinding algorithm which is based on the breadth width search
//but due to performance issue was scrapped, the idea is that it will spawn many objects of the pathStep class to surrounding location
//until it finds the way to the playerLastKnownPosition with consideration of walls and everything
public class PathFinder : MonoBehaviour
{
    private Vector3 startPoint;
    private Vector3 endPoint;
    private string theWay;
    private bool theWayISFound;
    //public PathStep firstStep;

    private void Awake()
    {
        theWayISFound = false;
    }
    public string FindingTheWay(Vector3 end, Vector3 start)
    {
        //the oversimplified version of the pathfinding with just simple
        theWay = null;
        int x = (int)(end.x - start.x);
        int y = (int)(end.y - start.y);
        if (x == 0 && y == 0)
        {
            theWay = "x";
        }
        else
        {
            if (x > 0)
            {
                while (x > 0)
                {
                    theWay = theWay + "d;";
                    x--;
                }
            }
            else
            {
                x = -x;
                while (x > 0)
                {
                    theWay = theWay + "a;";
                    x--;
                }
            }

            if (y > 0)
            {
                while (y > 0)
                {
                    theWay = theWay + "w;";
                    y--;
                }
            }
            else
            {
                y = -y;
                while (y > 0)
                {
                    theWay = theWay + "s;";
                    y--;
                }
            }
        }
        Debug.Log(theWay);
        return theWay;
    }

    public Vector3 Destination()
    {
        //return the destination where the way is going
        return endPoint;
    }

    public void WayIsFound(string realWay)
    {
        //from the pathStep, it will notify if the way is found or not
        //and also the way is given to theWay variable as string
        theWay = realWay;
        theWayISFound = true;
    }

    public bool IsWayFound()
    {
        return theWayISFound;
    }

    public string ShowMeTheWay()
    {
        theWayISFound = false;
        return theWay;
    }

    
}
