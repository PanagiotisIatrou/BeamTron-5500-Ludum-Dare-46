using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtonListeners : MonoBehaviour
{
    public GameObject HelpPanel;
    public static bool seesHelp = false;

    public void OnHelpButtonListener()
    {
        Time.timeScale = 0f;
        seesHelp = true;
        HelpPanel.SetActive(true);
    }

    public void OnCloseHelpButtonListener()
    {
        Time.timeScale = 1f;
        seesHelp = false;
        HelpPanel.SetActive(false);
    }
}
