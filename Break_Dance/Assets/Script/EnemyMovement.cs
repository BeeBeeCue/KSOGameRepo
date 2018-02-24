using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	public float moveSpeed;

	private Rigidbody2D myRigidBody;

	public bool isWalking;

	public float walkTime;
	private float walkCounter;
	public float waitTime;
	private float waitCounter;

	private int walkDirection;



	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();

		walkCounter = walkTime;
		waitCounter = waitTime;

		ChooseDirection ();
	}



	// Update is called once per frames
	void Update () {
		if (isWalking) 
		{
			walkCounter -= Time.deltaTime;



			switch(walkDirection)
			{
			case 0: 
				myRigidBody.velocity = new Vector2(0, moveSpeed);
				break;

			case 1: 
				myRigidBody.velocity = new Vector2(moveSpeed,0);
				break;

			case 2: 
				myRigidBody.velocity = new Vector2(0, -moveSpeed);
				break;

			case 3: 
				myRigidBody.velocity = new Vector2(-moveSpeed,0);
				break;
			}
				if (walkCounter < 0) {

					isWalking = false;
					waitCounter = waitTime;
				}

			
		}
		else {
			waitCounter -= Time.deltaTime;

			myRigidBody.velocity = Vector2.zero;

			if(waitCounter < 0)
			{
				ChooseDirection ();					
			}

		}

	}




	public void ChooseDirection()
	{
		walkDirection = Random.Range (0, 4);
		isWalking = true;
		walkCounter = walkTime;

	}
}
