using TMPro;
using UnityEngine;

public class ScoreManagerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    public void UpdateActualScore(int actualScore)
    {
        text.text = actualScore.ToString();
    }
}

