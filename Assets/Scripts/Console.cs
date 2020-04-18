using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Console : MonoBehaviour
{
    public TextMeshProUGUI ConsoleText;
    public GameObject CursorObj;
    private int maxCharactersPerLine = 19;
    private string text = "";

    private void Update()
    {
        foreach (char c in Input.inputString)
        {
            if (c == '\b')
            {
                if (text.Length != 0)
                {
                    text = text.Substring(0, text.Length - 1);
                }
            }
            else if ((c == '\n') || (c == '\r'))
            {
                text = "";
            }
            else
            {
                text += c;
            }
        }

        if (text.Length > maxCharactersPerLine)
            text = text.Substring(text.Length - maxCharactersPerLine, text.Length - 1);

        ConsoleText.SetText(text);

        if (ConsoleText.textInfo.characterCount > 0)
        {
            Vector3 bottomRight = ConsoleText.textInfo.characterInfo[ConsoleText.textInfo.characterCount - 1].bottomLeft;
            CursorObj.GetComponent<RectTransform>().localPosition = bottomRight += new Vector3(17f, 2f, 0f);
        }
        else
        {
            CursorObj.GetComponent<RectTransform>().localPosition = new Vector3(-115f, -5.16875f, 0f);
        }
    }
}
