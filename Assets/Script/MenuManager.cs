using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ChangeSceneAndStartGame()
    {
        // Charge la scène de jeu

        SceneManager.LoadSceneAsync(1);

    }

}
