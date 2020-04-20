using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AfterGameButtonListeners : MonoBehaviour
{
    public TextMeshProUGUI yearsText;
    public static int year;

    private void Awake()
    {
        yearsText.SetText("YOU MADE IT TO YEAR " + year + "!");
    }

    public void OnMainMenuButtonListener()
    {
        BlackFader.GoToScene("MainMenu", UnityEngine.SceneManagement.LoadSceneMode.Single, 0.8f);
    }

    public void OnRestartButtonListener()
    {
        BlackFader.GoToScene("Game", UnityEngine.SceneManagement.LoadSceneMode.Single, 0.8f);
    }
}
