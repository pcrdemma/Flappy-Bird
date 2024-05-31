using UnityEngine;
using UnityEngine.UI;

public class CanvaController : MonoBehaviour
{
    [SerializeField] private Text scoreUpdate;

    private void Start()
    {
        
        UpdateScore(GameManager.Instance.playerData.score);
    }
    public void UpdateScore(int score)
    {
        scoreUpdate.text = score.ToString();
    }
}