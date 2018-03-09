using System.Collections;
using System.Collections.Generic;
#pragma warning disable CS0234 // The type or namespace name 'UI' does not exist in the namespace 'UnityEngine' (are you missing an assembly reference?)
using UnityEngine.UI;
#pragma warning restore CS0234 // The type or namespace name 'UI' does not exist in the namespace 'UnityEngine' (are you missing an assembly reference?)
using UnityEngine;

public class BlinkingText : MonoBehaviour
{
    //Text text;
    //Image image;
#pragma warning disable CS0246 // The type or namespace name 'RawImage' could not be found (are you missing a using directive or an assembly reference?)
    RawImage image;
#pragma warning restore CS0246 // The type or namespace name 'RawImage' could not be found (are you missing a using directive or an assembly reference?)

	// Use this for initialization
	void Start ()
    {
        image = GetComponent<RawImage>();
        //text = GetComponent<Text>();
        StartBlinking();

	}
	
    IEnumerator Blink()
    {
        //while (true)
        //{
        //    switch(text.color.a.ToString())
        //    {
        //        case "0":
        //            text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        //            //play sound
        //            yield return new WaitForSeconds(0.5f);
        //            break;
        //        case "1":
        //            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        //            //play sound
        //            yield return new WaitForSeconds(0.5f);
        //            break;

        //    }

            while (true)
            {
                switch (image.color.a.ToString())
                {
                    case "0":
                        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
                        //play sound
                        yield return new WaitForSeconds(0.5f);
                        break;
                    case "1":
                        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
                        //play sound
                        yield return new WaitForSeconds(0.5f);
                        break;

                }



            }
    }


    void StartBlinking()
    {
        StopCoroutine("Blink");
        StartCoroutine("Blink");
    }
	
    void StopBlinking()
    {
        StopCoroutine("Blink");
    }
}
