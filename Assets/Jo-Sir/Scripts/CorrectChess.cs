using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectChess : MonoBehaviour
{
    private void Awake()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.name.Equals("CorrectPwan")) return;
        GameManager.Instance.DiceOnAble();
    }
}
