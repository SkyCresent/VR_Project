using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWall : MonoBehaviour
{
    private Rigidbody[] rbs;
    private GameObject parant;
    private float hp = 5;
    private void Awake()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        parant = this.transform.parent.gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.name.Equals("hammer")) return;
        hp--;
        if (hp == 3)
        {
            this.transform.SetParent(null);
            parant.SetActive(false);
        }
        else if (hp <= 0)
        { Break(); }
        Debug.Log(hp);
    }
    public void Break()
    {
        foreach (Rigidbody rb in rbs)
        {
            rb.transform.SetParent(null);
            rb.isKinematic = false; 
        }
        this.gameObject.SetActive(false);
    }
}
