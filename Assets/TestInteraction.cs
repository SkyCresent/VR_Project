using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteraction : MonoBehaviour,IInteraction
{
    public GameObject openObj;
    public void Interaction()
    {
        openObj.SetActive(true);
    }
    public void UnInteraction()
    {

    }
}
