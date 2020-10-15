using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField] private float speed = 4f;
    [SerializeField] private float jumpHeight = 25f;
     private float gravity = 1f;

    private float yVelocity = 0f;

    [SerializeField] private int currentLine = 1; //middle line

    [SerializeField] private bool leftStep = true;
    [SerializeField] private bool rightStep = true;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentLine--;
            if (currentLine == -1)
            {
                currentLine = 0;
                leftStep = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentLine++;
            if (currentLine == 3)
            {
                currentLine = 2;
                rightStep = true;
            }
        }
        
        Vector3 direction = new Vector3(0, 0, 1);
        Vector3 velocity = direction * speed;

        if (currentLine == 0 && leftStep)
        {
            velocity = Vector3.left * 50f;
            leftStep = false;
        }

        if (currentLine == 2 && rightStep)
        {
            velocity = Vector3.right * 50f;
            rightStep = false;
        }

        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                yVelocity = jumpHeight;
            }
        }

        else
        {
            yVelocity -= gravity;
        }


        velocity.y = yVelocity;

        controller.Move(velocity * Time.deltaTime);
    }

    void FixedUpdate()
    {
        
    }
}