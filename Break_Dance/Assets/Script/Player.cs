using UnityEngine;
using UnityEngine.SceneManagement;
namespace AssemblyCSharp
{

	public class Player : MonoBehaviour
	{
		public LayerMask wall, interactables;
		RaycastHit2D wallCheck;
		public Transform upCheck, downCheck, leftCheck, rightCheck, centre;
		private Transform temp;
		public float distance;
		private int delayedInput;
		private bool _look_right, playerIsSeen;
        private int score;
		private  bool playerMode = true, canMove, playerLose;
		private string playerAnswer, playerInput;
        private Timer timer;
        private EndingCanvas endCanvas;
        private int frameDelay;
		//playerMode, true means player in movement mode, false = puzzle mode

        private AudioSource beat;
        
        //when player enter certain zones, they will activate different script
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name == "Capture")
            {
                //when the player is in the 'capture' zone, the ending scene will play
                playerLose = true;
                endCanvas.score = score;
                endCanvas.finish_game = false;
                endCanvas.gameObject.SetActive(true);
            }
            else if (collision.gameObject.name == "Escape")
            {
				Debug.Log("enter");
				
				//when the player is in the escape zone, they will get to the next level

			}
            else if (collision.gameObject.name == "WinGame")
            {
                //when the player is in the win zone, the ending scene will play, and player win the game
                playerLose = false;
                endCanvas.score = score;
                endCanvas.finish_game = true;
                endCanvas.gameObject.SetActive(true);
            }

        }
		private void OnCollisionStay2D(Collision2D collision)
		{
			if (collision.gameObject.name == "Escape")
			{
				Debug.Log("enterStay");
				SceneManager.LoadScene("WinScene");
				//when the player is in the escape zone, they will get to the next level

			}
		}

		private void OnCollisionExit2D(Collision2D collision)
		{
            //the line of sight detection, this was scrapped
			if (collision.gameObject.name == "LineOSight")
			{
				playerIsSeen = false;
			}
		}
        
		
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
            endCanvas = GameObject.Find("EndingCanvas").GetComponent<EndingCanvas>();
            score = 0;
            endCanvas.gameObject.SetActive(false);
        }
        

		void Update()
		{
            if (!PauseMenu.GameIsPaused) 
            {
                //chekcing if the game is paused so that the player does not move when the pause menu is on
                delayedInput = -1;
                if (timer.CountBeat() == (timer.timeTilNextBeat-1))
                {
                    //this is to signal when the beat is play, after every period of timeTilNextBeat
                    beat.Play();
                    canMove = true;
                }
                if (playerMode && canMove)
                //playerMode is true means player in movement mode, and canMove signals player has not missbeat
                //the wallchecks are to check if there be any obstacle, aka wall in the direction the player is moving,
                //so that the player does not 'walk' into walls
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
                    //!playerMode is the puzzleInput mode for the player
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
                    //this check if the player miss the beat
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
            if (delayedInput > 10 && delayedInput < (timer.timeTilNextBeat-10))
            {
				Debug.Log("missed beat");
                score = score - 25;
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
            //player movement function, which teleports the player by a certain distance when pressing a button
            //for moving player about
            score = score + 10;
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
            //function to set player mode, move mode and puzzle mode
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
            //return player input when in puzzle mode
            return playerAnswer;
        }
        public string GetPlayerInput()
        {
            //get playerInput, playerAnswer = null is to delete the answer
            playerAnswer = null;
            return playerInput;
        }
        public void NullInput()
        {
            //null the playerInput
            playerInput = null;
        }
        public void NullAnswer()
        {
            //null the playerAnswer
            playerAnswer = null;
        }
        public bool DidPlayerLose()
        {
            //return condition if the player lose or not
            return playerLose;
        }

    }


}

