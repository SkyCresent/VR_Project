using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class BrokenWall : MonoBehaviour
{
    [SerializeField] private List<GameObject> browenWalls = new List<GameObject>();
    private List<Rigidbody> brownWallRigids = new List<Rigidbody>();
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject helpCube;
    [SerializeField] private GameObject planeX;
    private XRGrabInteractable[] xrGraps;
    [SerializeField] private BoxCollider[] aroundWallColls;
    private int brokenWallIndex = 0;

    private void Awake()
    {
        xrGraps = GetComponentsInChildren<XRGrabInteractable>();
        foreach (var xrGrap in xrGraps)
            xrGrap.enabled = false;

        foreach (var wall in browenWalls)
        {
            brownWallRigids.Add(wall.GetComponent<Rigidbody>());
            wall.transform.gameObject.SetActive(false);
        }

        

    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.V))
        // {
        //     Hit();
        // }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.name.Equals("HitCollider"))
            return;

        Hit();
        Music.Instance.PlaySound("breaking-a-wall(1)");
    }
    public void Break()
    {
        foreach (var coll in aroundWallColls)
            coll.isTrigger = true;
        wall.GetComponent<MeshRenderer>().enabled = false;
        planeX.SetActive(false);
        foreach (var rb in brownWallRigids)
            rb.isKinematic = false;

        foreach (var xrGrap in xrGraps)
            xrGrap.enabled = true;

        
        StartCoroutine(AroundWallOn());
    }



    IEnumerator AroundWallOn()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    private void Hit()
    {
        if (browenWalls.Count == brokenWallIndex)
        {
            Break();
            return;
        }

        for (int i = 0; i < 2; ++i, ++brokenWallIndex)
            browenWalls[brokenWallIndex].transform.gameObject.SetActive(true);
    }

}