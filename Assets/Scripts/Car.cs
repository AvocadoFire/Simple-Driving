using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] float carSpeed = 10;
    [SerializeField] float speedGainPerSec = .2f;
    [SerializeField] float turnSpeed = 200f;

    private int steerValue;

    void Update()
    {
        carSpeed += speedGainPerSec * Time.deltaTime;
        transform.Rotate(0, steerValue * turnSpeed *Time.deltaTime, 0);
        transform.Translate(Vector3.forward * carSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            CarScene();
        }
    }

    void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void CarScene()
    {

        SceneManager.LoadScene(1);
    }



    public void Steer(int value)
    {
        steerValue = value;
    }
}