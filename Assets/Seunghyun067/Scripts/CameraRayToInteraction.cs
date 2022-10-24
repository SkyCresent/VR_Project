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

    private InteractionToRay curObject;

    private void Interaction()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 5f, layerMask))
        {
            InteractionToRay targetObject = hit.transform.GetComponent<InteractionToRay>();

            if (targetObject == curObject)
                return;

            curObject?.InterationOff();
            curObject = targetObject;
            curObject.InterationOn();
        }
        else if(curObject)
        {
             curObject.InterationOff();
             curObject = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 5f);
    }

}
