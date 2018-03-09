using UnityEngine;
#pragma warning disable CS0234 // The type or namespace name 'UI' does not exist in the namespace 'UnityEngine' (are you missing an assembly reference?)
using UnityEngine.UI;
#pragma warning restore CS0234 // The type or namespace name 'UI' does not exist in the namespace 'UnityEngine' (are you missing an assembly reference?)
using System.Collections;
using TMPro;

public class ChatController : MonoBehaviour {


    public TMP_InputField TMP_ChatInput;

    public TMP_Text TMP_ChatOutput;

#pragma warning disable CS0246 // The type or namespace name 'Scrollbar' could not be found (are you missing a using directive or an assembly reference?)
    public Scrollbar ChatScrollbar;
#pragma warning restore CS0246 // The type or namespace name 'Scrollbar' could not be found (are you missing a using directive or an assembly reference?)

    void OnEnable()
    {
        TMP_ChatInput.onSubmit.AddListener(AddToChatOutput);

    }

    void OnDisable()
    {
        TMP_ChatInput.onSubmit.RemoveListener(AddToChatOutput);

    }


    void AddToChatOutput(string newText)
    {
        // Clear Input Field
        TMP_ChatInput.text = string.Empty;

        var timeNow = System.DateTime.Now;

        TMP_ChatOutput.text += "[<#FFFF80>" + timeNow.Hour.ToString("d2") + ":" + timeNow.Minute.ToString("d2") + ":" + timeNow.Second.ToString("d2") + "</color>] " + newText + "\n";

        TMP_ChatInput.ActivateInputField();

        // Set the scrollbar to the bottom when next text is submitted.
        ChatScrollbar.value = 0;

    }

}
