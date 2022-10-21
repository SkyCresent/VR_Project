using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera subCam;
    public bool issubCam = false;
    public bool isClicked = false;
    public float clicktimeMax = 0.5f;
    public float curClickTime = 0f;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) && !isClicked)
        {

            isClicked = true;
            BackCamControl();
        }
        if (isClicked)
            ClickedTime();
    }

    void BackCamControl()
    {
        issubCam = !issubCam;

        if (issubCam)
            subCam.rect = new Rect(0, 0, 1, 1);
        else
            subCam.rect = new Rect(0.05f, 0.85f, 0.1f, 0.1f);
    }
    void ClickedTime()
    {
        curClickTime += Time.deltaTime;

        if(curClickTime >= clicktimeMax)
        {
            isClicked = false;
            curClickTime = 0f;
        }
    }
}
