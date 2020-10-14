﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;

    private void Awake()
    {
        //target = GameObject.Find("Player").transform;
    }

    void Start()
    {
        offset = transform.position - target.position;
    }

    private void Update()
    {
        Vector3 newPosition = new Vector3(transform.position.x,transform.position.y, offset.z + target.position.z);
        transform.position = newPosition;
    }
}
