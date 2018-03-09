using UnityEngine;
using UnityEngine.UI;
using AssemblyCSharp;

public class GameCanvas : MonoBehaviour {

	private Text puzzleText;
	private string puzzleAnswer;
	private Player player;

	void Start()
	{
		puzzleText = GameObject.Find ("PuzzleText").GetComponent<Text> ();
		player = GameObject.Find ("Player").GetComponent<Player> ();
		player.SetPlayerMode ("move");
	}

	public void PuzzleDisplay(string puzzle)
	{
        player.SetPlayerMode("puzzle");
        puzzleAnswer = puzzle;
        puzzleText.text = puzzleAnswer;
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
                    puzzleText.text = "You are incorrect: "+puzzleAnswer;
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
