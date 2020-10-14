using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    
    private Vector3 direction;
    private Vector3 targetPosition;

    private float speedUp = 20f;

    private int currentLine = 0; //Left = -1 || Mid = 0 || Right = 1
    private int lineDistance = 1; //Distance between two lines;
    
    [SerializeField] private float forwardSpeed = 4f;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    private void Update()
    {
        direction.z = forwardSpeed;

        if (GameManager.distance >= speedUp)
        {
            speedUp *= 2f;
            forwardSpeed += 2f;
        }

        PlayerInput();

    }

    private void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentLine--;
            if (currentLine == -2)
            {
                currentLine = -1;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentLine++;
            if (currentLine == 2)
            {
                currentLine = 1;
            }
        }
        
        MoveCharacter();
    }
    
    private void MoveCharacter()
    {
        targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (currentLine == -1)
        {
            targetPosition += Vector3.left * lineDistance;
        }

        if (currentLine == 1)
        {
            targetPosition += Vector3.right * lineDistance;
        }

        transform.position = targetPosition;
    }

    void FixedUpdate()
    {
        controller.Move(direction*Time.fixedDeltaTime);
    }

}