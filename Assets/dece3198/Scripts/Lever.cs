using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    void Update()
    {
        if(transform.position.y > 0.1f)
        {
            transform.position = new Vector3(-0.244f, 0.1f, 0.058f);
        }
        else if(transform.position.y < -0.11f)
        {
            transform.position = new Vector3(-0.244f, -0.11f, 0.058f);
        }
    }
}
