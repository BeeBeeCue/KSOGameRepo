using UnityEngine;

public class Door : MonoBehaviour {

    private GameCanvas puzzleScreen;
    private bool isBeingInteracted;
    Collider2D box;
    Animator anim;
    public string puzzle, display;
    public string direction;
    public LayerMask layer;
    private int counter = 0;
    // Use this for initialization

    //Door is similar to interactibles, but the player interacts with them afar instead of walk into them
    //like the terminals.
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "UpCheck"  && isBeingInteracted == false)
        {
            if (puzzleScreen.AwaitingInteraction(direction))
            {
                counter++;
            }
            if (counter == 2)
            {
                isBeingInteracted = true;
                puzzleScreen.PuzzleDisplay(puzzle, display);
            }
        }
    }
    void Start () {
        puzzleScreen = GameObject.Find("PuzzleScreen").GetComponent<GameCanvas>();
        anim = GetComponent<Animator>();
        isBeingInteracted = false;
        box = GetComponent<BoxCollider2D>();
        anim.SetBool("open", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingInteracted)
        {
            if (puzzleScreen.SolvePuzzle())
            {
                isBeingInteracted = false;
                box.enabled = false;
                anim.SetBool("open", true);
                puzzleScreen.PuzzleStop();
            }
        }

    }  
}
