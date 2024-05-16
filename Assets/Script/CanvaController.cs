using UnityEngine;
using UnityEngine.UI;

public class CanvaController : MonoBehaviour
{
    [SerializeField] private Text scoreUpdate;
    public void UpdateScore(int score)
    {
        scoreUpdate.text = score.ToString();
    }
}
