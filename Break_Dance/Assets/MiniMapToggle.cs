using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MiniMapToggle : MonoBehaviour 
{

	public bool mapActive = false;
	public GameObject MiniMapObject;


	

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.M))
		{
			

			if (mapActive)
			{
				Debug.Log("You pressed M");
				MiniMapObject.SetActive(true);
				mapActive = true;
				Debug.Log("Map is on");
				return;
			}

			else
			{
				Debug.Log("You pressed M");
				MiniMapObject.SetActive(false);
				mapActive = false;
				Debug.Log("Map is off");
				return;
			}
			
		}

		

	}
	
	













}
