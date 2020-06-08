using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public static Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        
    }
    void LateUpdate()
    {
        transform.LookAt(transform.position + mainCamera.transform.up);
    }
}
