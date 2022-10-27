using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watch : SH.Interactionable
{

    private bool isWatch = false;

    private new void Awake()
    {
        base.Init(ItemOption.INTERACTION);
    }

    public override void Interaction()
    {
    }

    public override void UnInteraction()
    {
    }

    public override bool InteractionUpdate()
    {
        return isWatch;
    }

    public void DisableWath()
    {
        isWatch = false;
    }
}
