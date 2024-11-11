using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TMP_Text _textField;

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged += ScoreChanged;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChanged -= ScoreChanged;
    }

    private void ScoreChanged(float score)
    {
        _textField.text = score.ToString();
    }
}