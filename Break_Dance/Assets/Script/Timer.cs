using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    private int frames, second;
    private Transform playerPosition;
    private bool playerMissedBeat;
    
	// Use this for initialization
	void Start ()
    {
        frames = 0;
        second = 0;
        playerMissedBeat = false;
    }
	
	// Update is called once per frame
	void Update () {
        frames++;
        switch (frames)
        {
            case 59:
                break;
            case 60:
                frames = 0;
                second++;
                break;
        }
	}

    public void LostPlayer()
    {
        playerPosition = null;
    }

    public bool IsPlayerMissingABeat()
    {
        return playerMissedBeat;
    }

    public void Alarm(Transform position)
    {
        playerPosition = position;
        playerMissedBeat = true;
    }

    public int CountBeat()
    {
        return frames;
    }
}
