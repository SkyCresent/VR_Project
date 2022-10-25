using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycaster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
       if(Physics.Raycast(transform.position,transform.forward,out hit, 1000))
        {
            Debug.Log(hit.transform.name);
            hit.transform.GetComponent<Button>().onClick.Invoke();
        }
    }
}
