using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] public static float Speed = 4f;
    [SerializeField] public static bool GameLose = false;


    private Rigidbody _rb;

    [SerializeField] private float speedUpMeter = 20;
    
    [SerializeField] private ParticleSystem playerCrash;

    private int currentLine = 1; // middle Line


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Speed = 4f;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Instantiate(playerCrash, transform.position + Vector3.back + Vector3.up, Quaternion.identity);
            Speed = 0f;
            GameLose = true;
        }
    }

    void Update()
    {
        if (!GameLose)
        {

            PlayerInput();
            MovePlayer();


            if (GameManager.distance >= speedUpMeter)
            {
                speedUpMeter += speedUpMeter;
                Speed += 2f;
            }

            _rb.velocity = Vector3.forward * Speed;
        }
    }

    private void PlayerInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x > Screen.width * 0.5f)
            {
                //Right Tap
                currentLine++;
                if (currentLine == 3)
                {
                    currentLine = 2;
                }
            }

            else
            {
                //Left Tap
                currentLine--;
                if (currentLine == -1)
                {
                    currentLine = 0;
                }
            }
        }
    }

    void MovePlayer()
    {
        Vector3 direction = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (currentLine == 0)
        {
            direction.x = -1;
        }

        else if (currentLine == 1)
        {
            direction.x = 0;
        }

        else
        {
            direction.x = 1;
        }

        transform.position = direction;
    }
}