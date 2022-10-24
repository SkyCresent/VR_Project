using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotate : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(0f, -Input.GetAxis("Mouse X") * speed, 0f, Space.World);
            transform.Rotate(Input.GetAxis("Mouse Y") * speed, 0f, 0f);
        }
    }
}