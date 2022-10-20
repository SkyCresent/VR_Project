using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private TextMeshProUGUI objectText;

    private void Update()
    {
        Interaction();
    }


    private void Interaction()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward , out hit,5f, layerMask))
        {
            objectText.gameObject.SetActive(true);
            objectText.text = hit.transform.GetComponent<ObjectPickUp>().scrbleObject.objectName + "<color=yellow>" + " <G> " + "</color>";
        }
        else
        {
            objectText.gameObject.SetActive(false);
            objectText.text = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 5f);
    }

}
