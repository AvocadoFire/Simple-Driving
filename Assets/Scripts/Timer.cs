using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float timerLength = 30.0f;
    [SerializeField] Text timerDisplay;
    [SerializeField] int decimalPlaces = 0;

    void Update()
    {
        if (timerLength > 0)
        {
            timerLength -= Time.deltaTime;
        }

        double roundTimer = System.Math.Round(timerLength, decimalPlaces);

        timerDisplay.text = roundTimer.ToString();
        if (timerLength < 0)
        {
            FindObjectOfType<MainMenu>().HandleEnergyRefill();
        }

    }

}
