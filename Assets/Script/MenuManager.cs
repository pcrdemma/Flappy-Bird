using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ChangeSceneAndStartGame()
    {
        // Charge la sc�ne de jeu

        SceneManager.LoadSceneAsync(1);

    }

}
