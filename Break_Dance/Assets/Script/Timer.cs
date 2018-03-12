﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    private int frames, second;
    private Vector3 playerPosition;
    private bool playerMissedBeat;
    private bool playerIsSeen;
    public int timeTilNextBeat;
    
	// Use this for initialization
	void Start ()
    {
        frames = 0;
        second = 0;
        playerMissedBeat = false;
        playerIsSeen = false;
    }
	
	// Update is called once per frame
	void Update () {
        frames++;
        if (frames == timeTilNextBeat)
        {
            frames = 0;
            second++;
        }
    }

    public bool IsPlayerMissingABeat()
    {
        return playerMissedBeat;
    }
    public void Alarm(Vector3 position)
    {
        playerPosition = position;
        playerMissedBeat = true;
    }
    //line of sight method combo
    public void SeenAlarm(Vector3 position)
    {
        playerIsSeen = true;
        playerPosition = position;
    }

    public void SeenAlarmDisabled()
    {
        playerIsSeen = false;
    }

    public bool IsPlayerSeen()
    {
        return playerIsSeen;
    }
    //player no more miss his beat

    public void DisAlarm()
    {
        playerMissedBeat = false;
    }

    public Vector3 PlayerWasAt()
    {
        return playerPosition;
    }
    
    public int CountBeat()
    {
        return frames;
    }
}
