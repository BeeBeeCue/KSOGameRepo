using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateLimiter : MonoBehaviour {
	public int target = 60;


	void Start()
	{
		QualitySettings.vSyncCount = 0;
		
	}

	private void Update()
	{
		if (target != Application.targetFrameRate)
		{
			Application.targetFrameRate = target;

		}
	}
}
