using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateLimiter : MonoBehaviour {
	public int target = 60;

	//turns off vSync
	void Start()
	{
		QualitySettings.vSyncCount = 0;
		
	}

	//locks the framerate
	private void Update()
	{
		if (target != Application.targetFrameRate)
		{
			Application.targetFrameRate = target;

		}
	}
}
