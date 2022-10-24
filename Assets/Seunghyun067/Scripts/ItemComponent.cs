using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemOption
{
    NONE = 0,

    CLOSEUP = 1 << 0,
    INTERACTION = 1 << 1,
    HOVER = 1 << 2,
}

[RequireComponent(typeof(Item))]

public class ItemComponent : MonoBehaviour
{
    protected Item owner;

    protected void Init(ItemOption option)
    {
        if (!owner)
            owner = GetComponent<Item>();
        GetComponent<Item>().AddItemComponent(option, this);
    }

}
