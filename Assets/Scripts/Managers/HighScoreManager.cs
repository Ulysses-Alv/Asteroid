using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager instance;

    [SerializeField] private HighScoreManagerUI ui;

    private int actualHighScore;
    private bool surpassedHighscoreBefore = false;

    private void Awake()
    {
        instance = this;
        actualHighScore = PlayerPrefs.GetInt(StringTags.GetHighScoreString(), actualHighScore);
    }
    void Start()
    {
        ui.UpdateText(actualHighScore);
    }
    public void UpdateHighScore(int score)
    {
        if (score < actualHighScore) return;

        if (!surpassedHighscoreBefore)
        {
            HighScoreEffect.Instance.PlayHighscore(); 
            //esto es para que solo se haga una vez y no cada vez que se supera el puntaje anterior.
        }

        actualHighScore = score;
        PlayerPrefs.SetInt(StringTags.GetHighScoreString(), actualHighScore);
        ui.UpdateText(actualHighScore);
        surpassedHighscoreBefore = true;
    }
}
