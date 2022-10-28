using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallSwitchInter : SH.Interactionable
{
    private bool isLightOn = false;
    public override void Interaction()
    {
        isLightOn = GimmickManager.Instance.LightOn();
    }

    public override void UnInteraction()
    {
        if (isLightOn)
        {
            Music.Instance.PlaySound("switch");
            Debug.Log("불이 들어왔습니다");
            GetComponent<Animator>().SetTrigger("SmallSwitchOn");
            owner.DeleteOption(ItemOption.INTERACTION);
        }
        else
        {
            Debug.Log("전기가 없습니다");
        }
    }

    public override bool InteractionUpdate()
    {
        return false;
    }

}
