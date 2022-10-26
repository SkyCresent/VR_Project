using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomRaycaster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward * 100);
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(Physics.Raycast(transform.position,transform.forward,out hit, Mathf.Infinity))
            {
                Debug.Log(hit.transform.name);
                hit.transform.GetComponent<IInteraction>()?.Interaction();
            }

        }
    }
}
