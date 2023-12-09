using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Camera TheCamera;
    public Camera Cam;

    void Start()
    {
        TheCamera = Camera.main;
        TheCamera = GetComponent<Camera>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            TheCamera.enabled =!TheCamera.enabled;
            Cam.enabled = !Cam.enabled;
        }
    }
}
