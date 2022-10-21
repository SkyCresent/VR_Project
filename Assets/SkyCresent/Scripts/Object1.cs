using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object1 : MonoBehaviour
{
    [SerializeField]
    Image imageA;
    [SerializeField]
    Image imageX;
    [SerializeField]
    Camera mainCam;
    [SerializeField]
    Camera subCam;

    private void Start()
    {
        imageA.enabled = false;
        imageX.enabled = false;
        mainCam.enabled = false;
        subCam.enabled = true;
    }
    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "obj")
                {
                    imageA.enabled = true;
                }
            }
        }
        if (imageA.enabled == true && Input.GetKeyDown(KeyCode.A))
        {
            MainView();
            imageA.enabled = false;
            imageX.enabled = true;
        }
        if (imageA.enabled == false && Input.GetKeyDown(KeyCode.X))
        {
            SubView();
            imageX.enabled = false;
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
