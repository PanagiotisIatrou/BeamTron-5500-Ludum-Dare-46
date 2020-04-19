using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonListeners : MonoBehaviour
{
    public void OnPlayButtonListener()
    {
        BlackFader.GoToScene("Game", UnityEngine.SceneManagement.LoadSceneMode.Single, 1f);
    }
}
