using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Console : MonoBehaviour
{
    public TextMeshProUGUI ConsoleText;
    public GameObject CursorObj;
    private Image cursorImage;
    private int maxCharactersPerLine = 19;
    private string text = "";
    private bool cursorOn = true;
    private float cursorBlinkTimeMax = 0.3f;
    private float cursorBlinkTimer = 0f;

    private void Start()
    {
        cursorImage = CursorObj.GetComponent<Image>();
    }

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
                SendCommand(text);
                text = "C:\\";
            }
            else
            {
                text += c;
            }
        }

        if (text.Length > maxCharactersPerLine)
        {
            int diff = text.Length - maxCharactersPerLine;
            text = text.Substring(diff, text.Length - diff);
        }

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

        cursorBlinkTimer += Time.deltaTime;
        if (cursorBlinkTimer >= cursorBlinkTimeMax)
        {
            cursorBlinkTimer = 0f;
            cursorOn = !cursorOn;
            cursorImage.enabled = cursorOn;
        }
    }

    private void SendCommand(string command)
    {
        text = text.Substring(3, text.Length - 3);
        command = command.ToLower();
        if (command == "heal")
            Health.Heal(10);
    }
}
