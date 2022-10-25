using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAttack : MonoBehaviour
{
    public float atk = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IInteractions>() != null)
        {
            other.GetComponent<IInteractions>().TakeHit(atk);
        }
    }
}
