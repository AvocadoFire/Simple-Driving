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
    [SerializeField] private Button playButton;
    [SerializeField] private AndroidNotifHandler androidNotifHandler;
    [SerializeField] private iOSNotificationHandler iOSNotificationHandler;
    [SerializeField] private int maxEnergy;
    [SerializeField] private float energyRechargeDuration;
   //[SerializeField] Text timerDisplay;
   //[SerializeField] int decimalPlaces = 0;

   //float timeLeft = 30.0f;

    DateTime energyReady;
    private int energy;

    private const string EnergyKey = "Energy";
    private const string EnergyReadyKey = "EnergyReady";

    private void Start()
    {
        OnApplicationFocus(true);
    }
    private void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus) { return; }
        CancelInvoke();
        UpdateHighScore();
        HandleEnergyRefill();
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
#elif UNITY_IOS
            var minute = (int) energyRechargeDuration;
            iOSNotificationHandler.ScheduleNotification(minute);
#endif
        }
    }

    private void UpdateHighScore()
    {
        int highScore = PlayerPrefs.GetInt(ScoreText.HighScoreKey, 0);
        highScoreText.text = $"Your High Score:\n{highScore}";
    }
    public void HandleEnergyRefill()
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
            else
            {
                Invoke(nameof(EnergyRecharged), (energyReady - DateTime.Now).Seconds);
            }
        }
        energyText.text = $"Play :{energy}:";
    }

    private void EnergyRecharged()
    {
        energy = maxEnergy;
        PlayerPrefs.SetInt(EnergyKey, energy);
        energyText.text = $"Play ({energy})";
    }
}
