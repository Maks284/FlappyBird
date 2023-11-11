using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] 
    Bird _bird;
    [SerializeField]
    TMP_Text _score;

    private void OnEnable()
    {
        _bird.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _bird.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _score.text = score.ToString();
    }
}
