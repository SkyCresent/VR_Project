using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour, IInteractions
{
    [SerializeField]
    private GameObject fragments;
    [SerializeField]
    private MeshRenderer meshRenderer;

    private float hp;
    public float Hp 
    { 
        get { return hp; } 
        set 
        {
            hp = value;

        } 
    }

    private void Start()
    {
        Hp = 100f;
    }

    private void Update()
    {
        Debug.Log(hp);
        if (hp <= 0)
        {
            meshRenderer.enabled = false;
            fragments.SetActive(true);
            Destroy(gameObject, 5f);
        }
    }


    public void TakeHit(float damage)
    {
        hp -= damage;
    }

}
