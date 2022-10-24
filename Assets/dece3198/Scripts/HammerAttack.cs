using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAttack : MonoBehaviour
{
    public float atk = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<IInteractions>() != null)
        {
            collision.transform.GetComponent<IInteractions>().TakeHit(atk);
        }
    }
}
