using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using AssemblyCSharp;

public class Demon : MonoBehaviour
{
    public PathFinder pathFinder;
    public int distance;
    private Timer timer;
    
    private bool mode; //true is patrol mode, false is chase mode
    private bool look_right, playerIsInTheZone, searching;
    private string walkDirection;
    private PlayerLastPosition playerLastPosition;
    //private bool wallCheck;
    public Transform upCheck, downCheck, leftCheck, rightCheck, centre;
    public LayerMask wall;
    private int counter;
    public string walking;
    private List<string> walkInstance;
    // when player enter detection zone
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            if (playerLastPosition.IsPlayerFaulting(playerIsInTheZone) && !searching)
            {
                mode = false;
                SetDestination(playerLastPosition.transform.position);
                searching = true;
                timer.DisAlarm();
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

    IEnumerable SetDestination(Vector3 goal)
    {
        walkInstance.Clear();
        counter = 0;
        pathFinder.FindingTheWay(goal, this.transform.position);
        Debug.Log("the demon knows the way" + pathFinder.ShowMeTheWay());
        walkInstance = pathFinder.ShowMeTheWay().Split(';').ToList();
        searching = false;
        return null;
    }

    void Walk()
    {
        Debug.Log("start chasing");
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
            mode = true;
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
        counter = 0;
        walkInstance = walking.Split(';').ToList();
        playerIsInTheZone = false;
        look_right = true;
        mode = true;
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
        //}
        if (timer.CountBeat() == 59)
        {
            if (!mode)
            {
                Walk();
            }
        }
          
    }


}