using UnityEngine;
#pragma warning disable CS0234 // The type or namespace name 'UI' does not exist in the namespace 'UnityEngine' (are you missing an assembly reference?)
using UnityEngine.UI;
#pragma warning restore CS0234 // The type or namespace name 'UI' does not exist in the namespace 'UnityEngine' (are you missing an assembly reference?)
using AssemblyCSharp;

public class GameCanvas : MonoBehaviour
{

#pragma warning disable CS0246 // The type or namespace name 'Text' could not be found (are you missing a using directive or an assembly reference?)
	private Text puzzleText;
#pragma warning restore CS0246 // The type or namespace name 'Text' could not be found (are you missing a using directive or an assembly reference?)
	private string puzzleAnswer;
	private Player player;

	void Start()
	{
		puzzleText = GameObject.Find("PuzzleText").GetComponent<Text>();
		player = GameObject.Find("Player").GetComponent<Player>();
		player.SetPlayerMode("move");
	}

	public void PuzzleDisplay(string puzzle, string display)
	{
		player.SetPlayerMode("puzzle");
		puzzleAnswer = puzzle;
		puzzleText.text = display;
	}

	public bool SolvePuzzle()
	{
		bool temp = false;
		if (player.GetAnswer() != null)
		{

			if (player.GetAnswer().Length == puzzleAnswer.Length)
			{
				if (player.GetAnswer().Equals(puzzleAnswer))
				{
					Debug.Log(player.GetAnswer());
					puzzleText.text = "You are correct";
					player.SetPlayerMode("move");
					temp = true;
				}
				else
				{
					Debug.Log(player.GetAnswer());
					puzzleText.text = "You are incorrect,\r\n " +
						"back to Timo L! ";// + puzzleAnswer;
					player.SetPlayerMode("puzzle");
					temp = false;
				}
			}

		}
		return temp;
	}

	public void PuzzleStop()
	{
		puzzleText.text = null;
	}

	public bool AwaitingInteraction(string text)
	{
		player.NullAnswer();
		bool temp = false;
		if (player.GetPlayerInput() != null)
		{
			temp = player.GetPlayerInput().Equals(text);
		}
		player.NullInput();
		return temp;
	}






}
