using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using AssemblyCSharp;

public class Demon : MonoBehaviour
{
    public PathFinder pathFinder;
    public int distance;
    public int step;
    private Timer timer;
    
     //true is patrol mode, false is chase mode
    private bool look_right, playerIsInTheZone, chasing;
    private string walkDirection;
    
    private Vector3 originalLocation;
    private PlayerLastPosition playerLastPosition;
    public GameObject capture;
    //private bool wallCheck;
    public Transform upCheck, downCheck, leftCheck, rightCheck, centre;
    public LayerMask wall;
    private int counter;
    public string walking;
    private List<string> walkInstance;
    
    // when player enter detection zone, the demon will ask theLastKnownPosition if the player is missing a beat or not
    //if he is, the demon will go into chase mode and chase after the player (relentlessly)
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            if (playerLastPosition.IsPlayerFaulting(playerIsInTheZone))
            {
                SetDestination(playerLastPosition.transform.position);
                counter = 0;
            }
        }
    }
    //when player stays in detection zone
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerIsInTheZone = true;
        }
    }
    //when player gets out of detection zone
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            playerIsInTheZone = false; 
        }
    }

    //this is to get the path for the demon to walk to the player, which is calculated from the PathFInder
    void SetDestination(Vector3 goal)
    {
        walkInstance.Clear();
        walkInstance = pathFinder.FindingTheWay(goal, this.transform.position).Split(';').ToList();
        capture.SetActive(true);
        chasing = true;
    }

    //void FixedUpdate()
    //{
    //    if (chasing && knowTheWay == false)
    //    {
    //        if (pathFinder.IsWayFound())
    //        {
    //            walkInstance.Clear();
    //            walkInstance = pathFinder.ShowMeTheWay().Split(';').ToList();
    //            knowTheWay = true;
    //            capture.SetActive(true);
    //        } 
    //    }
    //}

    //the function for Demon movement, similar to player's movement, 
    //except for the wall checking, the demon is gonna go through wall
    private void  Walk()
    {
        Transform temp = leftCheck;
        walkDirection = walkInstance[counter];
        switch (walkDirection)
        {
            case "d":
                //wallCheck = Physics2D.Linecast(centre.transform.position, rightCheck.transform.position, wall);
                transform.position = new Vector2((float)(transform.position.x + distance), transform.position.y);
                look_right = true;
                break;
            case "w":
                //wallCheck = Physics2D.Linecast(centre.transform.position, upCheck.transform.position, wall);
                transform.position = new Vector2(transform.position.x, (float)(transform.position.y + distance));
                break;
            case "s":
                //wallCheck = Physics2D.Linecast(centre.transform.position, downCheck.transform.position, wall);
                transform.position = new Vector2(transform.position.x, (float)(transform.position.y - distance));
                break;
            case "a":
                //wallCheck = Physics2D.Linecast(centre.transform.position, leftCheck.transform.position, wall);
                transform.position = new Vector2((float)(transform.position.x - distance), transform.position.y);
                look_right = false;
                break;
        }
        counter++;
        if (counter == walkInstance.Count)
        {
           chasing = false;
           counter = 0;
           this.transform.position = originalLocation;
           capture.SetActive(false);
        }
        //this is for flipping the sprite when the move left and right
        Vector3 localScale = transform.localScale;
        if (((look_right == true) && (localScale.x < 0)) || (look_right == false) && (localScale.x > 0))
        {
            temp = leftCheck;
            leftCheck = rightCheck;
            rightCheck = temp;
            localScale.x = -localScale.x;
        }
        transform.localScale = localScale;
    }

    void Start()
    {
        chasing = false;
        originalLocation = this.transform.position;
        counter = 0;
        walkInstance = walking.Split(';').ToList();
        playerIsInTheZone = false;
        look_right = true;
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        playerLastPosition = GameObject.Find("PlayerLastKnownPosition").GetComponent<PlayerLastPosition>();    
    }

    // Update is called once per frames
    void Update()
    {
        //if (playerLastPosition.IsPlayerSeen() && searching)
        //{
        //    SetDestination(playerLastPosition.transform.position);
        //    searching = false;
        //}a

        //if the game paused from the pause menu, the demon will stop chasing
        //the demon moves to the beat, each time the beat reaches the threshold, it will move
        if (!PauseMenu.GameIsPaused)
        {            
            if (chasing && (timer.CountBeat() == timer.timeTilNextBeat-1))
            {
                for (int i = 0; i < step; i++)
                {
                    Walk();
                }
            }
        }
    }


}