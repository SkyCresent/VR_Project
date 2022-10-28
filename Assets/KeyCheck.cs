using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.name.Equals("Key")) return;
        GameManager.Instance.InsertKey();
    }
}
