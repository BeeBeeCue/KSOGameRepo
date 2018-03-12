using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour {

    public AudioSource source;
    public AudioClip hover;
    public AudioClip click;

	//Playes sound when button is hoverd
    public void OnHover()
    {
        source.PlayOneShot(hover);
    }
	//Playes sound when button is clicked
	public void OnClick()
    {
        source.PlayOneShot(click);
    }



}
