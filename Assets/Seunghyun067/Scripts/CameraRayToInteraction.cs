using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayToInteraction : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;

    private void Update()
    {
        Interaction();
    }

    private SH.Interactionable curObject;

    private void Interaction()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward * 5f, Color.red * 5f);
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5f, layerMask))
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
        else if(curObject)
        {
             curObject.HoverOff();
             curObject = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 5f);
    }

}
