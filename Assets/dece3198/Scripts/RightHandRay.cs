using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class RightHandRay : MonoBehaviour
{
    [SerializeField]
    private XRController controller;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private GameObject watchCanvas;

    private RaycastHit hitInfo;
    private bool isWtchUi = false;
    private bool isWatchCool = true;

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward, out hitInfo, 1f, layerMask))
        {
            if(hitInfo.transform.GetComponent<Watch>() != null)
            {
                if(controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool ButtonAX))
                {
                    if(ButtonAX)
                    {
                        isWtchUi = true;
                    }
                }
            }
        }

        if(isWtchUi && isWatchCool)
        {
            StartCoroutine(WatchUiCoolTime());
        }

    }

    IEnumerator WatchUiCoolTime()
    {
        watchCanvas.SetActive(true);
        isWatchCool = false;
        isWtchUi = false;
        yield return new WaitForSeconds(0.5f);
        isWatchCool = true;
    }
}
