using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectChess : MonoBehaviour
{
    private bool isOnable = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!isOnable)
        {
            isOnable = true;
            if (!other.name.Equals("CorrectPwan")) return;
            GameManager.Instance.DiceOnAble();
        }
    }
}
