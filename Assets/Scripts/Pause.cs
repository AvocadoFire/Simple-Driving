using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] Sprite buttonImageOriginal;
    [SerializeField] Sprite buttonImagePaused;

    Image buttonImage;
    
    Color buttonColor;
    bool isPaused = false;

    private void Start()
    {
       buttonImage = button.GetComponent<Image>();
    }

    public void Paused()
    {
        Debug.Log("entered paused");
        if (isPaused == false)
        {
        buttonImage.sprite = buttonImagePaused;
            Time.timeScale = 0;
        isPaused = true;
        return;
        }
        Time.timeScale = 1;
        isPaused = false;
        buttonImage.sprite = buttonImageOriginal;
    }
}
