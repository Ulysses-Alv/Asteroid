using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] private ScoreManagerUI ui;

    int actualScore;

    private void Awake()
    {
        instance = this;
    }
    public void AddScore(float health)
    {
        actualScore += Mathf.RoundToInt(health);
        ui.updateActualScore(actualScore);
        HighScoreManager.instance.UpdateHighScore(actualScore);
    }
}

