﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class PathStep : MonoBehaviour {

    private bool iFindTheWay;
    private PathFinder pathManager;
    public string theWay, rememberTheWay;
    private RaycastHit2D wallCheckUp, wallCheckDown, wallCheckLeft, wallCheckRight;
    public LayerMask wall;
    private PathStep stepUp, stepDown, stepRight, stepLeft;
    public PathStep step;

    private void Awake()
    {
        pathManager = GameObject.Find("PathFinder").GetComponent<PathFinder>();
        iFindTheWay = false;
    }
    // Use this for initialization
    private void Start ()
    {
        rememberTheWay = theWay;
        if (!pathManager.IsWayFound())
        {
            SmallStep();
        }  
    }

    IEnumerable SmallStep()
    {
        if (this.transform.position == pathManager.Destination())
        {
            pathManager.WayIsFound(theWay);
            iFindTheWay = true;
        }
        wallCheckUp    = Physics2D.Linecast(this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y + 1,0), wall);
        wallCheckDown  = Physics2D.Linecast(this.transform.position, new Vector3(this.transform.position.x, this.transform.position.y - 1,0), wall);
        wallCheckLeft  = Physics2D.Linecast(this.transform.position, new Vector3(this.transform.position.x - 1, this.transform.position.y,0), wall);
        wallCheckRight = Physics2D.Linecast(this.transform.position, new Vector3(this.transform.position.x + 1, this.transform.position.y,0), wall);

        if (wallCheckLeft.collider == null)
        {
            stepLeft = Instantiate(step, new Vector3(this.transform.position.x - 1, this.transform.position.y,0), Quaternion.Euler(new Vector3(0, 0, 0)), pathManager.transform) as PathStep;
            stepLeft.theWay = this.theWay + "a;";
            stepLeft.gameObject.SetActive(true);
            theWay = rememberTheWay;
        }
        if (wallCheckUp.collider == null)
        {
            //stepUp = new PathStep();
            stepUp = Instantiate(step, new Vector3(this.transform.position.x, this.transform.position.y + 1,0), Quaternion.Euler(new Vector3(0, 0, 0)), pathManager.transform) as PathStep;
            stepUp.theWay = this.theWay + "w;";
            stepUp.gameObject.SetActive(true);
            theWay = rememberTheWay;
        }
        if (wallCheckDown.collider == null)
        {
            //stepDown = new PathStep();
            stepDown = Instantiate(step, new Vector3(this.transform.position.x, this.transform.position.y - 1,0), Quaternion.Euler(new Vector3(0, 0, 0)), pathManager.transform) as PathStep;
            stepDown.theWay = this.theWay + "s;";
            stepDown.gameObject.SetActive(true);
            theWay = rememberTheWay;
        }
        
        if (wallCheckRight.collider == null)
        {
           // stepRight = new PathStep();
            stepRight = Instantiate(step, new Vector3(this.transform.position.x + 1, this.transform.position.y,0), Quaternion.Euler(new Vector3(0, 0, 0)), pathManager.transform) as PathStep;
            stepRight.theWay = this.theWay + "d;";
            stepRight.gameObject.SetActive(true);
            theWay = rememberTheWay;
        }
        return null;
    }

    void FixedUpdate()
    {
        if (pathManager.IsWayFound())
        {
            Destroy(this.gameObject);
        }
        
        Debug.DrawLine(this.transform.position, pathManager.transform.position, Color.blue);

        if (this.theWay == null)
        {
            Debug.DrawLine(this.transform.position, pathManager.Destination(), Color.red);
        }
    }




    // Update is called once per frame

}