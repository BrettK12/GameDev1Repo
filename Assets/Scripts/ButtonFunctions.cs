using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ButtonFunctions : MonoBehaviour
{
    public GameObject pausePanel;

    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        //Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void Retry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void Credits()
    {
        SceneManager.LoadScene("CreditsScene");
    }
}
