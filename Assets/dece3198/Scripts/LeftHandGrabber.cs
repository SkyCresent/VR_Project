using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandGrabber : MonoBehaviour
{
    public enum GRABBER_MODE
    { 
        DEFAULT, TOGGLE
    }


    [SerializeField]
    private GameObject curGrabbableObj;
    public GRABBER_MODE mode = GRABBER_MODE.DEFAULT;

    private void Update()
    {
        if(curGrabbableObj == null)
        {
            return;
        }

        switch (mode)
        {
            case GRABBER_MODE.DEFAULT:
                if (Input.GetButtonDown("Fire1"))
                {
                    if (curGrabbableObj.GetComponent<IGrabBeginInteractivable>().IsGrabed == false)
                    {
                        curGrabbableObj.GetComponent<IGrabBeginInteractivable>()?.GrabBegin(gameObject);
                    }
                    else
                    {
                        curGrabbableObj.GetComponent<IGrabBeginInteractivable>()?.GrabEnd(gameObject);
                    }
                }
                break;


            case GRABBER_MODE.TOGGLE:
                if(Input.GetButton("FIre1"))
                {
                    curGrabbableObj.GetComponent<IGrabBeginInteractivable>()?.GrabBegin(gameObject);
                }
                else
                {
                    curGrabbableObj.GetComponent<IGrabBeginInteractivable>()?.GrabEnd(gameObject);
                }
                break;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        IGrabBeginInteractivable tempGrabbable = other.GetComponent<IGrabBeginInteractivable>();
        if (tempGrabbable == null) return;
        curGrabbableObj = other.gameObject;
    }
    public void OnTriggerExit(Collider other)
    {
        IGrabBeginInteractivable tempGrabbable = other.GetComponent<IGrabBeginInteractivable>();
        if (tempGrabbable == null) return;
        curGrabbableObj = null;
    }
}
