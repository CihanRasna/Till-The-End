using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUps : MonoBehaviour
{
    private bool powerUp = false;
    private bool resetTimer;
    
    private Slider progressBar;

    private GameObject mySlider;
    
    private float powerUpTimer = 0f;

    private void Start()
    {
        mySlider = GameObject.Find("Slider");
        progressBar = mySlider.GetComponent<Slider>();
        mySlider.SetActive(false);
        //progressBar = GameObject.Find("Slider").GetComponent<Slider>();
        progressBar.value = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            powerUp = true;
            resetTimer = true;
            
        }
    }

    void Update()
    {
        if (powerUp)
        {
            mySlider.SetActive(true);
            Physics.IgnoreLayerCollision(8, 9, true);
            powerUpTimer += Time.deltaTime;
            if (resetTimer)
            {
                powerUpTimer = 0f;
                resetTimer = false;
            }
            else if (powerUpTimer >= 5f)
            {
                Physics.IgnoreLayerCollision(8, 9, false);
                powerUp = false;
                powerUpTimer = 0f;
                mySlider.SetActive(false);
            }

            progressBar.value = powerUpTimer / 5f;
        }
    }
}
