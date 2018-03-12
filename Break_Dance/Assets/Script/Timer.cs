using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Timer : MonoBehaviour {
    private int frames, second;
    private Vector3 playerPosition;
    private bool playerMissedBeat;
    private bool playerIsSeen;
    public int timeTilNextBeat;
    

	// Use this for initialization
	void Start()
	{
		frames = 0;
		second = 0;
		playerMissedBeat = false;
		playerIsSeen = false;
	}
    
	// Update is called once per frame

	void Update () {
        //count the frames in the game, which dictates whether the player moves according to the beat and signal the demon to move
        frames++;
        if (frames == timeTilNextBeat)
        {
            frames = 0;
            second++;
        }
    }



	public bool IsPlayerMissingABeat()
	{
        //return a bool signaling whether the player is missing a beat or not
		return playerMissedBeat;
	}
	public void Alarm(Vector3 position)
	{
		playerPosition = position;
		playerMissedBeat = true;
	}
	//line of sight method combo, this was actually scapped
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
	

	public void DisAlarm()
	{
        //player no more miss his beat so the alarms
        playerMissedBeat = false;
	}

	public Vector3 PlayerWasAt()
	{
        //send the player position over
		return playerPosition;
	}

	public int CountBeat()
	{
        //return the frame count to other classes
		return frames;
	}
}
