using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoader : MonoBehaviour
{

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void loadStartScene()
    {
        SceneManager.LoadScene(0);
        NewMethod();

        
    }
    public void NewMethod()
    {
        FindObjectOfType<GameSession>().Resetgame();
    }


    public void QuitGame()
    {
        Application.Quit();
    }


}