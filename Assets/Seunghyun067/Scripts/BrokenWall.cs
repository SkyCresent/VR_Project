using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenWall : MonoBehaviour
{
    [SerializeField] private List<GameObject> browenWalls = new List<GameObject>();
    private List<Rigidbody> brownWallRigids = new List<Rigidbody>();
    [SerializeField] private GameObject Wall;
    [SerializeField] private GameObject helpCube;
    private float hp = 5;
    private int brokenWallIndex = 0;

    private void Awake()
    {
        foreach (var wall in browenWalls)
        {
            brownWallRigids.Add(wall.GetComponent<Rigidbody>());
            wall.transform.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (browenWalls.Count == brokenWallIndex)
            {
                Break();
                return;
            }

            for (int i = 0; i < 2; ++i, ++brokenWallIndex)
                browenWalls[brokenWallIndex].transform.gameObject.SetActive(true);
            Debug.Log(hp);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.name.Equals("hammer")) return;
        hp--;
        if (hp == 0)
            Break(); 
        Debug.Log(hp);
    }
    public void Break()
    {
        Wall.GetComponent<MeshRenderer>().enabled = false;
        foreach (var rb in brownWallRigids)
            rb.isKinematic = false;
        //StartCoroutine(HelpCube());
    }

    IEnumerator HelpCube()
    {
        float time = 0.3f;
        float scaleX = helpCube.transform.localScale.x;
        while (time > 0f)
        {
            time -= Time.deltaTime;
            helpCube.transform.localScale = new Vector3(scaleX += Time.deltaTime * 20f, helpCube.transform.localScale.y, helpCube.transform.localScale.z);
            yield return null;
        }
        Destroy(helpCube.gameObject);
        foreach (var rb in browenWalls)
            Destroy(rb);
    }


}