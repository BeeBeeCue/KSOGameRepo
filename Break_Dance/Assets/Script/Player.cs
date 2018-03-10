using UnityEngine;




namespace AssemblyCSharp
{

    public class Player: MonoBehaviour
	{
        public LayerMask wall, interactables;
		RaycastHit2D wallCheck;
        public Transform upCheck, downCheck, leftCheck, rightCheck, centre;
        private Transform temp;
		public float distance;
        private int delayedInput;
		private bool _look_right, playerIsSeen;
		private  bool playerMode = true, canMove, playerLose;
		private string playerAnswer, playerInput;
        private Timer timer;

        private int frameDelay;
		//playerMode, true means player in movement mode, false = puzzle mode

		public Player ()
		{

		}
        
        private AudioSource beat;
        
        //playerMode, true means player in movement mode, false = puzzle mode
        

		//to set player mode
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name == "Capture")
            {
                playerLose = true;
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.name == "LineOSight")
            {
                wallCheck = Physics2D.Linecast(centre.transform.position, collision.transform.position, wall);
                if(wallCheck.collider != null)
                {
                    playerIsSeen = false;
                }
                else
                {
                    playerIsSeen = true;
                }
                
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.name == "LineOSight")
            {
                playerIsSeen = false;
            }
        }


        //player movement function, which teleports the player by a certain distance when pressing a button
        //for moving player about
        
		void Start()
		{
            canMove = true;
            Debug.Log("Game Start");
            delayedInput = -1;
            _look_right = true;
            playerLose = false;
            playerInput = null;
			playerAnswer = null;
            timer = GameObject.Find("Timer").GetComponent<Timer>();
            beat = GetComponent<AudioSource>();
        }
        
		void Update()
		{
            if (!PauseMenu.GameIsPaused)
            {
                delayedInput = -1;
                if (timer.CountBeat() == (timer.timeTilNextBeat-1))
                {
                    beat.Play();
                    canMove = true;
                }
                if (playerMode && canMove)

                {
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        wallCheck = Physics2D.Linecast(centre.transform.position, leftCheck.transform.position, wall);
                        delayedInput = timer.CountBeat();
                        if (wallCheck.collider == null)
                        {
                            this.Move("left");
                        }
                        playerInput = "A";
                    }
                    else if (Input.GetKeyDown(KeyCode.S))
                    {
                        wallCheck = Physics2D.Linecast(centre.transform.position, downCheck.transform.position, wall);
                        delayedInput = timer.CountBeat();
                        if (wallCheck.collider == null)
                        {
                            this.Move("down");
                        }
                        playerInput = "S";

                    }
                    else if (Input.GetKeyDown(KeyCode.D))
                    {
                        wallCheck = Physics2D.Linecast(centre.transform.position, rightCheck.transform.position, wall);
                        delayedInput = timer.CountBeat();
                        if (wallCheck.collider == null)
                        {
                            this.Move("right");
                        }
                        playerInput = "D";

                    }
                    else if (Input.GetKeyDown(KeyCode.W))
                    {
                        wallCheck = Physics2D.Linecast(centre.transform.position, upCheck.transform.position, wall);
                        delayedInput = timer.CountBeat();
                        if (wallCheck.collider == null)
                        {
                            this.Move("up");
                        }
                        playerInput = "W";

                    }
                }
                else if (!playerMode)
                {
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        playerAnswer += "A";
                    }
                    else if (Input.GetKeyDown(KeyCode.S))
                    {
                        playerAnswer += "S";
                    }
                    else if (Input.GetKeyDown(KeyCode.D))
                    {
                        playerAnswer += "D";
                    }
                    else if (Input.GetKeyDown(KeyCode.W))
                    {
                        playerAnswer += "W";

                    }
                }

                //when player misses his beat
                if (delayedInput != -1)
                {
                    PlayerGettingHeard();
                }
                //when player is in sight zone
                //if (playerIsSeen)
                //{
                //    timer.SeenAlarm(transform.position);
                //    delayedInput = -1;
                //}
                //else
                //{
                //    timer.SeenAlarmDisabled();
                //}
            }

        }

        private void PlayerGettingHeard()
        {
            if (delayedInput > 6 && delayedInput < (timer.timeTilNextBeat-6))
            {
                timer.Alarm(transform.position);
                delayedInput = -1;
                canMove = false;
            }
            else
            {
                timer.DisAlarm();
            }
        }

        private void Move(string input)
        {

            switch (input)
            {
                case "up":
                    transform.position = new Vector2(transform.position.x, (float)(transform.position.y + distance));
                    break;
                case "left":
                    transform.position = new Vector2((float)(transform.position.x - distance), transform.position.y);
                    _look_right = false;
                    break;
                case "right":
                    transform.position = new Vector2((float)(transform.position.x + distance), transform.position.y);
                    _look_right = true;
                    break;
                case "down":
                    transform.position = new Vector2(transform.position.x, (float)(transform.position.y - distance));
                    break;
            }
            //frameDelay = timer.CountBeat();
            //player sprite flipping when turn left and right during movement
            Vector3 localScale = transform.localScale;
            if (((_look_right == true) && (localScale.x < 0)) || (_look_right == false) && (localScale.x > 0))
            {
                temp = leftCheck;
                leftCheck = rightCheck;
                rightCheck = temp;
                localScale.x = -localScale.x;
            }

            transform.localScale = localScale;
        }

        public void SetPlayerMode(string x)
        {
            switch (x)
            {
                case "move":
                    playerMode = true;
                    playerAnswer = null;
                    break;
                case "puzzle":
                    playerMode = false;
                    playerAnswer = null;
                    break;
            }

        }
        public string GetAnswer()
        {
            return playerAnswer;
        }
        public string GetPlayerInput()
        {
            playerAnswer = null;
            return playerInput;
        }
        public void NullInput()
        {
            playerInput = null;
        }
        public void NullAnswer()
        {
            playerAnswer = null;
        }
        public bool DidPlayerLose()
        {
            return playerLose;
        }

    }

}

