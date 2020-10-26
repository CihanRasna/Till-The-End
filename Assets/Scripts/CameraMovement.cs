using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    private Vector3 zOffset;

    void Start()
    {
        zOffset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 newPosition = new Vector3(target.position.x,transform.position.y, zOffset.z + target.position.z);
        transform.position = newPosition;
    }
}
