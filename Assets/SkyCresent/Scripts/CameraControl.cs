using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    Camera mainCam;
    [SerializeField]
    Camera subCam;

    void Start()
    {
        mainCam.enabled = false;
        subCam.enabled = true;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            MainView();
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            SubView();
        }
    }

    public void MainView()
    {
        mainCam.enabled = true;
        subCam.enabled = false;
    }
    public void SubView()
    {
        mainCam.enabled = false;
        subCam.enabled = true;
    }
}
