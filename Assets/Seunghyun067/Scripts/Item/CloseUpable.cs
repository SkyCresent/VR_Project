using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUpable : ItemComponent, ICloseUp
{
    [SerializeField] private string closeUpLayer = "Default";
    public int CloseUpLayer { get => LayerMask.NameToLayer(closeUpLayer); }

    protected void Awake()
    {
        base.Init(ItemOption.CLOSEUP);

        if (closeUpLayer.Length == 0)
            closeUpLayer = "Default";
    }
    public virtual void CloseUp()
    {
    }

    public virtual void UnCloseUp()
    {
    }

    public virtual void CloseUpUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(0f, -Input.GetAxis("Mouse X") * 3, 0f, Space.World);
            transform.Rotate(Input.GetAxis("Mouse Y") * 3, 0f, 0f);
        }
    }
}