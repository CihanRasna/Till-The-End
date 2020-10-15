using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    
    public Vector3 direction;
    public Vector3 targetPosition;

    

    private int currentLine = 1; //Left = 0 || Mid = 1 || Right = 2
    private int lineDistance = 1; //Distance between two lines;
    
    [SerializeField] private float forwardSpeed = 4f;
    private float jumpForce = 10f;
    private float gravity = -20f;
    private float speedUp = 20f;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (GameManager.distance >= speedUp)
        {
            speedUp *= 2f;
            forwardSpeed += 2f;
        }

        PlayerInput();
        MoveCharacter();
    }
    
    void FixedUpdate()
    {
         direction.z = forwardSpeed;
         controller.Move(direction*Time.fixedDeltaTime);
    }

    private void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentLine--;
            if (currentLine == -1)
            {
                currentLine = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentLine++;
            if (currentLine == 3)
            {
                currentLine = 2;
            }
        }
        
        if (controller.isGrounded)
        {
            //direction.y = -1f;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction.y = jumpForce;
            }
        }
        else
        {
            direction.y += gravity*Time.deltaTime;
        }

    }
    
    private void MoveCharacter()
    {
        targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (currentLine == 0)
        {
            targetPosition += Vector3.left * lineDistance;
        }

        if (currentLine == 2)
        {
            targetPosition += Vector3.right * lineDistance;
        }


        transform.position = targetPosition;
    }

}