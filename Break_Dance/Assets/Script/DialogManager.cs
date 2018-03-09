using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour 
{

    private Queue<string> sentenses;









	// Use this for initialization
	void Start () 
    {
        sentenses = new Queue<string>();	
	}
	


    public void StartDialog (Dialog dialog)
    {
        Debug.Log("convo starter" + dialog.name);
    }
	
}
