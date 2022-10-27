using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class RightHandRay : MonoBehaviour
{
    [SerializeField] private GameObject point;
    [SerializeField]
    private XRController controller;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private GameObject watchCanvas;

    [SerializeField] LineRenderer line;

    private RaycastHit hitInfo;
    private bool isWtchUi = false;
    private bool isWatchCool = true;

    // Update is called once per frame
    private void Awake()
    {
        watchCanvas.SetActive(false);
    }
    void Update()
    {
        
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 1f, layerMask))
        {
            point.SetActive(true);
            point.transform.position = hitInfo.point;
            Debug.Log(hitInfo.transform.name);
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
        else
        point.SetActive(false);

        if (isWtchUi && isWatchCool)
        {
            StartCoroutine(WatchUiCoolTime());
        }

    }

    public void DisabledWatch()
    {
        watchCanvas.SetActive(false);
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
