using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour {

	//Loads the welcome screen
	public void LoadMainMenu()
	{
		SceneManager.LoadScene("WinScoreEnter");
	}
}
