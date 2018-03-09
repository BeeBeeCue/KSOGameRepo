using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WelcomeScript : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update ()
    {
        //On any key click, load next scene
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        

	}








}
