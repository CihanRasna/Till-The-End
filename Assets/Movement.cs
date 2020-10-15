using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    private float speed = 4f;
    private float jumpHeight = 500f;
    private Rigidbody _rb;
    private float yVelocity;
    private float speedUpMeter = 20;
    private bool isGrounded = true;

    private int currentLine = 1; // middle Line
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        
        if (GameManager.distance >= speedUpMeter)
        {
            speedUpMeter *= 2f;
            speed += 2f;
        }
        
        PlayerInput();
        MovePlayer();
        
        _rb.velocity = Vector3.forward * speed;

        if (transform.position.y <= 1.1)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void PlayerInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentLine--;
            if (currentLine == -1)
            {
                currentLine = 0;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            currentLine++;
            if (currentLine == 3)
            {
                currentLine = 2;
            }
        }
    }

    void MovePlayer()
    {
        Vector3 direction = new Vector3(transform.position.x,transform.position.y,transform.position.z);

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

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
            }
        }
        
        

        transform.position = direction;
    }
}
