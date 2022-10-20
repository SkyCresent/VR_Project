using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TestRay : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] Transform target;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { ShootRay(); }
    }
    private void ShootRay()
    {
        Vector3 mos = Input.mousePosition;
        mos.z = camera.farClipPlane;
        Vector3 dir = camera.ScreenToWorldPoint(mos);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, dir, out hit, mos.z))
        {
            target.position = new Vector3(hit.point.x, 0f, hit.point.z);
        }
    }
        
}
