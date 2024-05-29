using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{

    [SerializeField] GameObject pausePanel;

    public void Pause ()
    {
        pausePanel.SetActive(true);
    }
    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Play()
    {
        pausePanel.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
