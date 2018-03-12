
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevelTrigger : MonoBehaviour
{
	public float delayTime = 2;
	

	private void OnTriggerStay2D(Collider2D collision)
	{
		StartCoroutine(Leveltrigger());
	}
	

	//waits 2 sec then loads the next scene
	IEnumerator Leveltrigger ()
	{
		
		yield return new WaitForSeconds(delayTime);
		Debug.Log("nextscene");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

}
