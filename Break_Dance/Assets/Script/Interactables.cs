using UnityEngine;
using UnityEngine.UI;
#pragma warning disable CS0234 // The type or namespace name 'UI' does not exist in the namespace 'UnityEngine' (are you missing an assembly reference?)
#pragma warning restore CS0234 // The type or namespace name 'UI' does not exist in the namespace 'UnityEngine' (are you missing an assembly reference?)

public class Interactables : MonoBehaviour {

	private GameCanvas puzzleScreen;
    private bool isBeingInteracted;
    Collider2D box;
    Animator anim;
	[TextArea(8, 10)]
	public string puzzle, display;
    public Light screenLight;
	private bool puzzleIsSolved = false;
		// Use this for initialization

	//check if the player enter the puzzle zone
	void OnCollisionEnter2D(Collision2D collide)
	{
		if (collide.gameObject.name == "Player") 
		{
            isBeingInteracted = true;
			puzzleScreen.PuzzleDisplay(puzzle, display);
		}
	}

    //return the state of the puzzle whether it is being interacted with or not

    void Start () {
		puzzleScreen = GameObject.Find ("PuzzleScreen").GetComponent<GameCanvas> ();
        anim = GetComponent<Animator>();
        isBeingInteracted = false;
        box = GetComponent<BoxCollider2D>();
        box.enabled = true;
    }
	// Update is called once per frame
	void Update () {
        if (isBeingInteracted)
        {
            if (puzzleScreen.SolvePuzzle())
            {
                isBeingInteracted = false;
                box.enabled = false;
                anim.SetBool("on", false);
                screenLight.intensity = 0;
                puzzleScreen.PuzzleStop();
				puzzleIsSolved = true;
            }
        }
		
		if (puzzleIsSolved == true)
		{
			Destroy(GameObject.Find("Door"));
		}
	}
}
