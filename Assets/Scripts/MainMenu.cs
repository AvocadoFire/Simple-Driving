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
    [SerializeField] private AndroidNotifHandler androidNotifHandler;
    [SerializeField] private int maxEnergy;
    [SerializeField] private float energyRechargeDuration;

    DateTime energyReady;

    private int energy;

    private const string EnergyKey = "Energy";
    private const string EnergyReadyKey = "EnergyReady";

    private void Start()
    {
        UpdateHighScore();
        HandleEnergyRefill();
    }

    private void Update()
    {
        if (energy > 0)
        {
            energyText.text = $"Play :{energy}:";
        }
        energyText.text = $"Not enough energy";
    }

    public void Play()
    {

        HandleEnergyRefill();
        NotificationNeedEnergy();

    }

    private void NotificationNeedEnergy()
    {
        if (energy < 1)
        {
            energyText.text = $"Not enough energy";
            return;
        }

        energy--;
        PlayerPrefs.SetInt(EnergyKey, energy);
        SceneManager.LoadScene("Car Scene");

        if (energy == 0)
        {
            DateTime energyReady = DateTime.Now.AddMinutes(energyRechargeDuration);
            PlayerPrefs.SetString(EnergyReadyKey, energyReady.ToString());
#if UNITY_ANDROID
            androidNotifHandler.ScheduleNotification(energyReady);
#endif
        }
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

            energyReady = DateTime.Parse(energyReadyString);

            if (DateTime.Now > energyReady)
            {
                energy = maxEnergy;
                PlayerPrefs.SetInt(EnergyKey, energy);
            }
        }

        energyText.text = $"Play :{energy}:";
    }



}
