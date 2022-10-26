using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watch : SH.Interactionable
{
    [SerializeField]
    private GameObject watchUI;

    private bool isWatch = false;

    private new void Awake()
    {
        base.Init(ItemOption.INTERACTION);
        watchUI.SetActive(false);
    }

    public override void Interaction()
    {
        watchUI.SetActive(true);
    }

    public override void UnInteraction()
    {
        watchUI.SetActive(isWatch);
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
