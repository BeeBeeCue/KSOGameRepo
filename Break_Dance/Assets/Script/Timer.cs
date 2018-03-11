using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class Timer : MonoBehaviour
{
	private int frames, second;
	private Vector3 playerPosition;
	private bool playerMissedBeat;
	private bool playerIsSeen;

=======
public class Timer : MonoBehaviour {
    private int frames, second;
    private Vector3 playerPosition;
    private bool playerMissedBeat;
    private bool playerIsSeen;
    public int timeTilNextBeat;
    
>>>>>>> df702d39bdf93b98bdd915ca4a4fdcb555e2ba89
	// Use this for initialization
	void Start()
	{
		frames = 0;
		second = 0;
		playerMissedBeat = false;
		playerIsSeen = false;
	}




	// Update is called once per frame
<<<<<<< HEAD
	void Update()
	{
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

		if (Input.GetKeyDown(KeyCode.Space))
		{
			playerMissedBeat = true;
		}
	}
=======
	void Update () {
        frames++;
        if (frames == timeTilNextBeat)
        {
            frames = 0;
            second++;
        }
>>>>>>> df702d39bdf93b98bdd915ca4a4fdcb555e2ba89

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
