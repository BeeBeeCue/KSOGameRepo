using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Demon : MonoBehaviour
{
    public int distance;
    private Timer timer;
    private Transform destination;
    private bool mode = true; //true is patrol mode, false is chase mode
    private bool look_right;
    private string walkDirection;

    private Rigidbody2D myRigidBody;
    RaycastHit2D wallCheck;

    public Transform upCheck, downCheck, leftCheck, rightCheck, centre;
    public LayerMask wall;
    private int counter;

    public string walking;
    private List<string> walkInstance;
    // Use this for initialization

    public void ChangeMode(Transform position)
    {
        mode = false;//chase mode
        destination = position;
    }

    void Walk()
    {
        Transform temp;
        walkDirection = walkInstance[counter];
        switch (walkDirection)
        {
            case "d":
                wallCheck = Physics2D.Linecast(centre.transform.position, rightCheck.transform.position, wall);
                transform.position = new Vector2((float)(transform.position.x + distance), transform.position.y);
                look_right = true;
                break;
            case "w":
                wallCheck = Physics2D.Linecast(centre.transform.position, upCheck.transform.position, wall);
                transform.position = new Vector2(transform.position.x, (float)(transform.position.y + distance));
                break;
            case "s":
                wallCheck = Physics2D.Linecast(centre.transform.position, downCheck.transform.position, wall);
                transform.position = new Vector2(transform.position.x, (float)(transform.position.y - distance));
                break;
            case "a":
                wallCheck = Physics2D.Linecast(centre.transform.position, leftCheck.transform.position, wall);
                transform.position = new Vector2((float)(transform.position.x - distance), transform.position.y);
                look_right = false;
                break;
        }
        counter++;
        if (counter == walkInstance.Count)
        {
            counter = 0;
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
        myRigidBody = GetComponent<Rigidbody2D>();
        timer = GameObject.Find("Timer").GetComponent<Timer>();
        look_right = true;

        walkInstance = walking.Split(';').ToList();
    }
    // Update is called once per frames
    void Update()
    {
        if (timer.IsPlayerMissingABeat())
        {

        }
        if (timer.CountBeat() == 59)
        {
            Walk();
        }
        
    }


}