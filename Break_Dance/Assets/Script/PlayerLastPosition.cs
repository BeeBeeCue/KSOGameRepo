using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AssemblyCSharp;

public class PlayerLastPosition : MonoBehaviour {
    
    private Timer timer;
	// Use this for initialization
	void Start () {
        timer = GameObject.Find("Timer").GetComponent<Timer>();
	}
    //checking if player is missing a beat
    public bool IsPlayerFaulting(bool playerIsInTheZone)
    {
        bool temp = false;
        if (timer.IsPlayerMissingABeat() && playerIsInTheZone)
        {
            temp = true;
            transform.position = timer.PlayerWasAt();
            timer.DisAlarm();
        }
        return temp;
    }

    //checking if player is seen by enemy
    public bool IsPlayerSeen()
    {
        bool temp = false;
        if (timer.IsPlayerSeen())
        {
            temp = true;
            transform.position = timer.PlayerWasAt();
            timer.SeenAlarmDisabled();
        }
        return temp;
    }
	// Update is called once per frame
	void Update ()
    {
        
	}
}
