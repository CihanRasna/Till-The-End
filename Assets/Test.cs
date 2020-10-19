using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x > Screen.width / 2)
            {
                Debug.Log("sagclick");
            }
            else
            {
                Debug.Log("solclick");
            }
        }
        
    }
}
