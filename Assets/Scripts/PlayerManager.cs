using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerManager : MonoBehaviour
{
    public AudioClip[] playerSFX;
    public AudioSource audioSource;

    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    public static float speed = 4f;
    public static bool isGameLose = false;
    public static bool isGameStarted = false;

    private Rigidbody _rb;

    [SerializeField] private float lineChangeSpeed = 5f;
    [SerializeField] private float speedUpMeter = 20f;

    [SerializeField] private ParticleSystem playerCrash;

    private int currentLine = 1; // middle Line
    private int preLine;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody>();
        speed = 0f;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Instantiate(playerCrash, transform.position + Vector3.back + Vector3.zero, Quaternion.identity);
            speed = 0f;
            audioSource.PlayOneShot(playerSFX[4]);
            audioSource.PlayOneShot(playerSFX[5]);
            isGameLose = true;
        }
    }

    void Update()
    {
        if (isGameStarted)
        {
            if (!isGameLose)
            {
                SwipeInput();

                if (GameManager.distance >= speedUpMeter)
                {
                    speedUpMeter += speedUpMeter;
                    speed += 2f;
                }

                _rb.velocity = Vector3.forward * speed;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isGameLose)
        {
            MovePlayer();
        }
    }

    private void SwipeInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            int randomSfx = Random.Range(0, playerSFX.Length - 2);

            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            currentSwipe.Normalize();

            //swipe left
            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                currentLine--;
                if (currentLine == -1)
                {
                    currentLine = 0;
                }

                audioSource.PlayOneShot(playerSFX[randomSfx]);
            }

            //swipe right
            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                currentLine++;
                if (currentLine == 3)
                {
                    currentLine = 2;
                }

                audioSource.PlayOneShot(playerSFX[randomSfx]);
            }
        }
    }

    private void TapInput()
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