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
    GameObject mainCam;
    [SerializeField]
    GameObject subCam;
    [SerializeField]
    private Transform objectPrefab;
    [SerializeField]
    private Transform uiPoint;

    private GameObject curObject;
    private GameObject curObj;

    private bool isCloseUp = false;

    private void Awake()
    {
        imageA.enabled = false;
        imageX.enabled = false;
        mainCam.gameObject.SetActive(false);
        subCam.gameObject.SetActive(true);
    }
    private void Update()
    {
        if(!isCloseUp && Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "obj")
                {
                    imageA.enabled = true;
                    curObject = hit.transform.gameObject;
                }
            }
        }
        UiInteraction();
    }

    void UiInteraction()
    {
        if (imageA.enabled == true && Input.GetKeyDown(KeyCode.A))
        {
            ObjectCreate();
            MainView();
            imageA.enabled = false;
            imageX.enabled = true;
            isCloseUp = true;
        }
        if (imageA.enabled == false && Input.GetKeyDown(KeyCode.X))
        {
            SubView();
            Destroy(curObj);
            imageX.enabled = false;
            isCloseUp = false;

        }
    }

    public void MainView()
    {
        //mainCam.enabled = true;
        //subCam.enabled = false;
        subCam.gameObject.SetActive(false);
        mainCam.gameObject.SetActive(true);
    }
    public void SubView()
    {
        mainCam.gameObject.SetActive(false);
        subCam.gameObject.SetActive(true);
    }

    void ObjectCreate()
    {
        curObj = Instantiate(curObject, uiPoint.position, uiPoint.rotation);
        curObj.AddComponent<ObjectRotate>();
        
    }
}
