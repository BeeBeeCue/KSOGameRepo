using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    private int frames, second;
    private AudioSource beat;
	// Use this for initialization
	void Start () {
        frames = 0;
        second = 0;
        beat = GetComponent<AudioSource>();
        
	}
	
	// Update is called once per frame
	void Update () {
        frames++;
        switch (frames)
        {
            case 59:
                beat.Play();
                break;
            case 60:
                frames = 0;
                second++;
                break;
        }
	}

    public int CountBeat()
    {
        return frames;
    }
}
