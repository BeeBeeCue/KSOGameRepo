using System.Collections;
using UnityEngine;
#pragma warning disable CS0234 // The type or namespace name 'UI' does not exist in the namespace 'UnityEngine' (are you missing an assembly reference?)
using UnityEngine.UI;
#pragma warning restore CS0234 // The type or namespace name 'UI' does not exist in the namespace 'UnityEngine' (are you missing an assembly reference?)


public class PuzzleGameController : MonoBehaviour
{

	private int num;
	//private int guessNumber;

	private int countGuess;




#pragma warning disable CS0246 // The type or namespace name 'InputField' could not be found (are you missing a using directive or an assembly reference?)

#pragma warning restore CS0246 // The type or namespace name 'InputField' could not be found (are you missing a using directive or an assembly reference?)


	[SerializeField]
	private GameObject btn;


	[SerializeField]
	private InputField input;

	[SerializeField]
#pragma warning disable CS0246 // The type or namespace name 'Text' could not be found (are you missing a using directive or an assembly reference?)
	private Text text;
#pragma warning restore CS0246 // The type or namespace name 'Text' could not be found (are you missing a using directive or an assembly reference?)

	//At start, generate a random number and then displays what the game requires i.e to guess a number between
	void Awake()
	{
		num = Random.Range(0, 100);
		text.text = "Guess a number between 0 and 100";
		Debug.Log(" The number is " + num);
	}

	//This controls the getting of input
	public void GetInput(string guess)
	{
		CompareGuesses(int.Parse(guess));
		input.text = ("");
		countGuess++;
	}

	//When you guess right or wrong , what happens
	void CompareGuesses(int guess)
	{


		if (guess == num)
		{
			text.text = "You guessed correctly. The number was " + guess + ". You had to guess " + countGuess + "x. Do you want to play again?";
			//This boolean activates the play again button
			btn.SetActive(true);
		}
		else if (guess > num)
		{

			text.text = "The number we are looking for is less than your guess";
		}

		else if (guess < num)
		{

			text.text = "The number we are looking for is greater than your guess";
		}
	}

	// the method that is executed when you wish to play again
	public void PlayAgain()
	{
		num = Random.Range(0, 100);
		text.text = "Guess a number between 0 and 100";
		countGuess = 0;
		btn.SetActive(false);
		Debug.Log(" The number is " + num);

	}
}
