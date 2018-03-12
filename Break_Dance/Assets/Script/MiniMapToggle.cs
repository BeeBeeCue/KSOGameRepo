using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MiniMapToggle : MonoBehaviour
{

	public bool mapActive = false;
	public GameObject miniMapObject;

	//finds the minimap object
	private void Start()
	{
		miniMapObject = GameObject.Find("MiniMapObject");



	}

	void Update()
	{

		//if m is pressed either turn on or off the minimap
		if (Input.GetKeyDown(KeyCode.M))
		{

			Debug.Log("I pressed M");
			if (!mapActive)
			{
				Debug.Log("You pressed M");
				miniMapObject.SetActive(true);
				mapActive = true;
				Debug.Log("Map is on");
				return;
			}

			if (mapActive)
			{
				Debug.Log("You pressed M");
				miniMapObject.SetActive(false);
				mapActive = false;
				Debug.Log("Map is off");
				return;
			}

		}



	}















}
