using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void ChangeSceneAndRestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
