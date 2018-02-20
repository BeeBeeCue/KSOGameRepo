using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    public static GameMaster gm;


    //cache
    private AudioManagerBrackyes audioManager;


    void Start()
    {
        //caching
        audioManager = AudioManagerBrackyes.instance;
        if (audioManager == null)
        {
            Debug.LogError("FREAK OUT, No audio manager found in the scene");
        }

    }
}
