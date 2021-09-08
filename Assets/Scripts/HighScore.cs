using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    [SerializeField] private Text highScoreText;
    int highScore = 0;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt(ScoreText.HighScoreKey, 0);
        highScoreText.text = $"Your High Score: {highScore}";
    }
}
