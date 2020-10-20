using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static float Speed = 4f;
    public static bool isGameLose = false;
    public static bool isGameStarted = false;


    private Rigidbody _rb;

    [SerializeField] private float lineChangeSpeed = 5f;
    [SerializeField] private float speedUpMeter = 20;

    [SerializeField] private ParticleSystem playerCrash;

    private int currentLine = 1; // middle Line
    private int preLine;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Speed = 0f;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Instantiate(playerCrash, transform.position + Vector3.back + Vector3.zero, Quaternion.identity);
            Speed = 0f;
            isGameLose = true;
        }
    }

    void Update()
    {
        if (isGameStarted)
        {
            if (!isGameLose)
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
        var position = transform.position;
        Vector3 left = new Vector3(position.x - 1, position.y, position.z);
        Vector3 right = new Vector3(position.x + 1, position.y, position.z);


        if (currentLine == 0)
        {
            position = Vector3.Lerp(position, left, Time.deltaTime * lineChangeSpeed);
            if (position.x <= -1f)
            {
                position.x = -1;
            }

            preLine = currentLine;
        }

        else if (currentLine == 2)
        {
            position = Vector3.Lerp(position, right, Time.deltaTime * lineChangeSpeed);
            if (position.x >= 1f)
            {
                position.x = 1;
            }

            preLine = currentLine;
        }

        else if (currentLine == 1 && preLine == 0)
        {
            position = Vector3.Lerp(position, right, Time.deltaTime * lineChangeSpeed);
            if (position.x >= 0f)
            {
                position.x = 0;
            }
        }

        else
        {
            position = Vector3.Lerp(position, left, Time.deltaTime * lineChangeSpeed);
            if (position.x <= 0f)
            {
                position.x = 0;
            }
        }

        transform.position = position;
    }
}