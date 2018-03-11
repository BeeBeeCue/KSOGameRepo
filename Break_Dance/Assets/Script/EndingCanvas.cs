using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingCanvas : MonoBehaviour {

    private Text title_Text;
    private string[] alphabet = new string[]{"A","B","C","D", "E", "F", "G", "H" , "I", "J", "K", "L" , "M", "N", "O", "P" , "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    private Text[] text_array = new Text[3];
    private Text final_text;
    private int[] index_temp = new int[3];
    private int index_text, index_alphabet;
    private DatabaseManager data;
    private string playerName;
    private Color color_one, color_two;
    private bool mode; //true = input name, false = display ranking

    public int score;
    public bool finish_game;
	// Use this for initialization
	void Awake () {
        text_array[0] = GameObject.Find("EndText_First").GetComponent<Text>();
        text_array[1] = GameObject.Find("EndText_Second").GetComponent<Text>();
        text_array[2] = GameObject.Find("EndText_Third").GetComponent<Text>();
        title_Text = GameObject.Find("Title").GetComponent<Text>();
        final_text = GameObject.Find("FinalText").GetComponent<Text>();
        data = GameObject.Find("DataManager").GetComponent<DatabaseManager>();
        score = 0;
        finish_game = false;
        mode = true;
        color_one = text_array[0].color;
        color_two = text_array[1].color;
    }

    private void Start()
    {
        title_Text.text = "GAME OVER!\nYOUR NAME";
        index_alphabet = 0;
        index_text = 0;
        final_text.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
        if (mode)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                text_array[index_text].color = color_one;
                index_text--;
                if (index_text < 0)
                {
                    index_text = 2;
                }
                index_alphabet = index_temp[index_text];
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                text_array[index_text].color = color_one;
                index_text++;
                if (index_text > 2)
                {
                    index_text = 0;
                }
                index_alphabet = index_temp[index_text];
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                index_alphabet--;
                if (index_alphabet < 0)
                {
                    index_alphabet = 25;
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                index_alphabet++;
                if (index_alphabet > 25)
                {
                    index_alphabet = 0;
                }
            }
            text_array[index_text].color = color_two;
            index_temp[index_text] = index_alphabet;
            text_array[index_text].text = alphabet[index_alphabet];
            playerName = text_array[0].text + text_array[1].text + text_array[2].text;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && mode)
        {
            title_Text.gameObject.SetActive(false);
            text_array[0].gameObject.SetActive(false);
            text_array[1].gameObject.SetActive(false);
            text_array[2].gameObject.SetActive(false);
            final_text.gameObject.SetActive(true);
            data.AddResult(playerName,score,finish_game);
            mode = false;
            final_text.text = data.DisplayResult(final_text.text);
        }

    }
}
