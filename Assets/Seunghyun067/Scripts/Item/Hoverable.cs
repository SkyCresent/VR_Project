using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoverable : ItemComponent, IHoverable
{
    [SerializeField] private Renderer[] myRenderers;

    [SerializeField, Range(0, 0.01f)] private float outlineWidth;
    [SerializeField] private int outlineOverWidth = 1;

    void Awake()
    {
        base.Init(ItemOption.HOVER);
        if (myRenderers.Length == 0)
            myRenderers = GetComponentsInChildren<Renderer>();

        foreach (var render in myRenderers)
            render.material.SetFloat("_Outline", 0f);
    }

    public void HoverOff()
    {
        foreach (var render in myRenderers)
            render.material.SetFloat("_Outline", 0f);
    }

    public void HoverOn()
    {
        foreach (var render in myRenderers)
            render.material.SetFloat("_Outline", outlineWidth * outlineOverWidth);
    }
}
