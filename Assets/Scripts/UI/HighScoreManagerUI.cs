using TMPro;
using UnityEngine;

public class HighScoreManagerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    public void UpdateText(int actualHighScore)
    {
        text.text = actualHighScore.ToString();
    }
}
