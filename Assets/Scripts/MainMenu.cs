using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text highScoreText;
    [SerializeField] private Text energyText;
    [SerializeField] private int maxEnergy;
    [SerializeField] private int energyRechargeDuration;
   

    private const string EnergyKey = "Energy";
    private const string EnergyReadyKey = "EnergyReady";

    private int energy;


    private void Start()
    {
        UpdateHighScore();
        HandleEnergyRefill();
    }

    public void Play()
    {
        if (energy < 1)
        {
            energyText.text = $"Not enough energy";
            return;
        }

        energy--;
        PlayerPrefs.SetInt (EnergyKey, energy);

        if (energy == 0)
        {
            DateTime energyReady = DateTime.Now.AddMinutes(energyRechargeDuration);
            PlayerPrefs.SetString(EnergyReadyKey, energyReady.ToString());
        }

        SceneManager.LoadScene("Car Scene");
    }

    private void UpdateHighScore()
    {
        int highScore = PlayerPrefs.GetInt(ScoreText.HighScoreKey, 0);
        highScoreText.text = $"Your High Score:\n{highScore}";
    }
    private void HandleEnergyRefill()
    {
        energy = PlayerPrefs.GetInt(EnergyKey, maxEnergy); //default to max
        if (energy == 0)
        {
            string energyReadyString = PlayerPrefs.GetString(EnergyReadyKey, string.Empty);
            if (energyReadyString == string.Empty) { return; }

            DateTime energyReady = DateTime.Parse(energyReadyString);

            if (DateTime.Now > energyReady)
            {
                energy = maxEnergy;
                PlayerPrefs.SetInt(EnergyKey, energy);
            }
        }

        energyText.text = $"Play :{energy}:";
    }



}
