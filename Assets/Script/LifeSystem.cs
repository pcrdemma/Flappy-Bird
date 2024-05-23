using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public Image[] heartImages; // Assign these in the Inspector
    private int life;

    private void Start()
    {
        life = heartImages.Length; // Initialize life to the number of heart images
    }

    private void Update()
    {
        // Ensure life is within the bounds of the heartImages array
        if (life < 0)
        {
            life = 0;
        }
        else if (life > heartImages.Length)
        {
            life = heartImages.Length;
        }

        // Update the heart images based on the current life count
        for (int i = 0; i < heartImages.Length; i++)
        {
            heartImages[i].enabled = (i < life);
        }

        // Check for game over condition
        if (life <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void Damage(int damageAmount)
    {
        life -= damageAmount;
        if (life < 0)
        {
            life = 0;
        }
    }

}
