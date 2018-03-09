using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    private Vector3 startPoint;
    private Vector3 endPoint;
    private string theWay;
    private bool theWayISFound;
    public PathStep firstStep;

    private void Awake()
    {
        theWay = "x;x";
        theWayISFound = false;
    }
    public void FindingTheWay(Vector3 end, Vector3 start)
    {
        this.transform.position = start;
        startPoint = start;
        endPoint = end;
        theWayISFound = false;
        Instantiate(firstStep, startPoint, Quaternion.Euler(new Vector3(0,0,0)), this.transform);
        firstStep.theWay = null;
        
        firstStep.gameObject.SetActive (true);
        
    }

    public Vector3 Destination()
    {
        return endPoint;
    }

    public void WayIsFound(string realWay)
    {
        theWay = realWay;
        Debug.Log(theWay + "is true");
        theWayISFound = true;
    }

    public bool IsWayFound()
    {
        return theWayISFound;
    }

    public string ShowMeTheWay()
    {
        return theWay;
    }

    
}
