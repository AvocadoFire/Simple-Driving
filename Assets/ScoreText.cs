using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] float pointIncreasePerSecond = 1;
    float score = 0;
    float scoreChange = 0;
    
    void Update()
    {
        scoreChange += pointIncreasePerSecond * Time.deltaTime;
        score = (int)scoreChange;
        scoreText.text = score.ToString();
    }
}
