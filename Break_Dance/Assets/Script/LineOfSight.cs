using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour {

    private bool seePlayer;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            seePlayer = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            seePlayer = false;
        }
    }
    // Use this for initialization
    void Start () {
        seePlayer = false;
	}

    public bool SeenPlayer()
    {
        return seePlayer;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
