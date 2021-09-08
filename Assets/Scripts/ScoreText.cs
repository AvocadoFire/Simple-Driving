using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] float pointIncreasePerSecond = 1;

    public const string HighScoreKey = "HighScore" ;

    int score = 0;
    float scoreChange = 0;
    
    void Update()
    {
        scoreChange += pointIncreasePerSecond * Time.deltaTime;
        score = (int)scoreChange;
        scoreText.text = score.ToString();
    }

    private void OnDestroy()
    {
        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        if(score > currentHighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, score);
        }
    }
}
