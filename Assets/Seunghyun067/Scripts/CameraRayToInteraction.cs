using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraRayToInteraction : MonoBehaviour
{
    [SerializeField] Image imageA;
    [SerializeField] Image imageX;
    [SerializeField] Camera mainCam;
    [SerializeField] Camera subCam;
    [SerializeField] private Transform uiPoint;


    [SerializeField]
    private LayerMask layerMask;

    private bool isCloseUp = false;

    private GameObject curUIObject;
    private SH.Interactionable curObject;
    RaycastHit hit;
    private void Awake()
    {
        imageA.enabled = false;
        imageX.enabled = false;
        mainCam.enabled = true;
        subCam.enabled = false;
    }


    private void Update()
    {
        subCam.transform.position = mainCam.transform.position;
        subCam.transform.rotation = mainCam.transform.rotation;
        uiPoint.position = mainCam.transform.position + mainCam.transform.forward;
        
        Interaction();
    }


    private void Interaction()
    {        
        UiInteraction();

        Debug.DrawRay(transform.position, transform.forward * 5f, Color.red * 5f);
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 5f, layerMask))
        {
            if (!isCloseUp)
                SetHoverObject();
        }
        else if(curObject)
        {
             curObject.HoverOff();
             curObject = null;
        }

        
    }

    void SetHoverObject()
    {
        SH.Interactionable targetObject = null;
        if (!(targetObject = hit.transform.GetComponent<SH.Interactionable>()))
            return;

        if (targetObject == curObject)
            return;

        curObject?.HoverOff();
        curObject = targetObject;
        curObject.HoverOn();
    }
    void UiInteraction()
    {
        if (!isCloseUp && Input.GetMouseButtonUp(0))
        {
            imageA.enabled = true;
            curUIObject = curObject.transform.gameObject;
        }

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
            Destroy(curUIObject);
            imageX.enabled = false;
            isCloseUp = false;

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 5f);
    }

    public void MainView()
    {
        mainCam.enabled = false;
        subCam.enabled = true;
    }
    public void SubView()
    {
        mainCam.enabled = true;
        subCam.enabled = false;
    }

    void ObjectCreate()
    {
        curUIObject = Instantiate(curUIObject, uiPoint.position, uiPoint.rotation);
        curUIObject.AddComponent<ObjectRotate>();

        if (curUIObject.GetComponent<Rigidbody>())
            curUIObject.GetComponent<Rigidbody>().useGravity = false;
    }

}
