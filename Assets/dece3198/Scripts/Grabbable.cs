using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour, IGrabBeginInteractivable
{
    public bool IsGrabed { get; set; }

    public void GrabBegin(GameObject grabberObj)
    {
        IsGrabed = true;
        if (GetComponent<Rigidbody>() != null)
            GetComponent<Rigidbody>().isKinematic = true;
        transform.parent = grabberObj.transform;
    }

    public void GrabEnd(GameObject grabberObj)
    {
        IsGrabed = false;
        if (GetComponent<Rigidbody>() != null)
            GetComponent<Rigidbody>().isKinematic = false;
        transform.parent = null;
    }
}
