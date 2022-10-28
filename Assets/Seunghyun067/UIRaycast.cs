using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;


public class UIRaycast : MonoBehaviour
{
    [SerializeField] private XRRayInteractor[] xrRays;

    float xrRayLength;

    private void Start()
    {
        if (xrRays.Length <= 0)
            return;
        xrRayLength = xrRays[0].maxRaycastDistance;
    }

    private void OnEnable()
    {
        foreach (var xrRay in xrRays)
            xrRay.maxRaycastDistance = 100;
    }

    private void OnDisable()
    {
        foreach (var xrRay in xrRays)
            xrRay.maxRaycastDistance = xrRayLength;
    }


}
