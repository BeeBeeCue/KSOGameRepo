using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class PuzzleGameController : MonoBehaviour {

	private int num;
	//private int guessNumber;

	private int countGuess;

	[SerializeField]
	private InputField input;


	[SerializeField]
	private Text text;

	void Awake () {
		num = Random.Range (0, 100);
		text.text = "Guess a number between 0 and 100";

		//guessNumber = (int.Parse (guess));
	}

	public void GetInput (string guess) {
		CompareGuesses (int.Parse (guess));
		input.text = ("");
	}

	void CompareGuesses(int guess){


		if (guess == num ) {
		text.text= "You guessed correctly. The number was "+ guess;
		} 
		else if (guess > num) {

			text.text= "The number we are looking for is less than your guess";
		}

		else if (guess < num) {

			text.text= "The number we are looking for is greater than your guess";
		}

	
	}
}
