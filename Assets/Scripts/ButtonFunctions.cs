using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ButtonFunctions : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject instructionsPanel;

    AudioSource soundEffect;

    void Start()
    {
        soundEffect = gameObject.GetComponent<AudioSource>();
    }

    public void NewGame()
    {
        if (PlayerPrefs.HasKey("PointsID"))
            PlayerPrefs.DeleteKey("PointsID");

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

    public void NextLevel()
    {
        SaveStuff();
        SceneManager.LoadScene("Level2");
    }

    public void StartTheLevel()
    {
        soundEffect.Play();
        Time.timeScale = 1;
        instructionsPanel.SetActive(false);
        
    }

    public void Continue()
    {
        if (PlayerPrefs.HasKey("PointsID"))
            SceneManager.LoadScene("Level2");
    }

    public void SaveStuff()
    {
        PlayerPrefs.SetInt("PointsID", PointsManager.GetPointValue());
    }
}
