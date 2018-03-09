using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //When you press play game it takes that game scene and plays next in que
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    //Quits the application
    public void QuitGame ()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
	
}
