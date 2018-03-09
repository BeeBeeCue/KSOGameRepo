using System.Collections;
using UnityEngine;
#pragma warning disable CS0234 // The type or namespace name 'UI' does not exist in the namespace 'UnityEngine' (are you missing an assembly reference?)
using UnityEngine.UI;
#pragma warning restore CS0234 // The type or namespace name 'UI' does not exist in the namespace 'UnityEngine' (are you missing an assembly reference?)


public class PuzzleGameController : MonoBehaviour {

	private int num;
	//private int guessNumber;

	private int countGuess;

	[SerializeField]
#pragma warning disable CS0246 // The type or namespace name 'InputField' could not be found (are you missing a using directive or an assembly reference?)
	private InputField input;
#pragma warning restore CS0246 // The type or namespace name 'InputField' could not be found (are you missing a using directive or an assembly reference?)


	[SerializeField]
#pragma warning disable CS0246 // The type or namespace name 'Text' could not be found (are you missing a using directive or an assembly reference?)
	private Text text;
#pragma warning restore CS0246 // The type or namespace name 'Text' could not be found (are you missing a using directive or an assembly reference?)

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
