using TMPro;
using UnityEngine;

public class ScoreManagerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    public void updateActualScore(int actualScore)
    {
        text.text = actualScore.ToString();
    }
}

