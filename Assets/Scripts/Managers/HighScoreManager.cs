using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager instance;
    
    [SerializeField] private HighScoreManagerUI ui;

    int actualHighScore;

    private void Awake()
    {
        instance = this;
        actualHighScore = PlayerPrefs.GetInt("High Score", actualHighScore);
    }
    void Start()
    {
        ui.UpdateText(actualHighScore);
    }
    public void UpdateHighScore(int score)
    {
        if (score < actualHighScore) return;

        actualHighScore = score;
        PlayerPrefs.SetInt("High Score", actualHighScore);
        ui.UpdateText(actualHighScore);
    }
}
