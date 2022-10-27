using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ObjectRotate : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    // Update is called once per frame
    void Update()
    {
        if(XRInput.Instance.LeftController.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
        {
            transform.Rotate(0f, -position.x * speed, 0f, Space.World);
            transform.Rotate(position.y * speed, 0f, 0f, Space.World);
        }

        if (XRInput.Instance.RightController.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position2))
        {
            transform.Rotate(0f, -position2.x * speed, 0f, Space.World);
            transform.Rotate(position2.y * speed, 0f, 0f, Space.World);
        }
        // if (Input.GetMouseButton(0))
        // {
        //     transform.Rotate(0f, -Input.GetAxis("Mouse X") * speed, 0f, Space.World);
        //     transform.Rotate(Input.GetAxis("Mouse Y") * speed, 0f, 0f, Space.World);
        // }
    }
}
