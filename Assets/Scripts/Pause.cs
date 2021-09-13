using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    bool isPaused = false;
    public void Paused()
    {
        Debug.Log("entered paused");
        if (isPaused == false)
        {
        Time.timeScale = 0;
        isPaused = true;
        return;
        }
        Time.timeScale = 1;
        isPaused = false;

    }
}
