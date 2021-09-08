using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text highScoreText;
    int highScore = 0;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt(ScoreText.HighScoreKey, 0);
        highScoreText.text = $"Your High Score:\n{highScore}";
    }
    public void Play()
    {
        SceneManager.LoadScene("Car Scene");
    }
}
