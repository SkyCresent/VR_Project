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
            Debug.Log("���� ���Խ��ϴ�");
            GetComponent<Animator>().SetTrigger("SmallSwitchOn");
            owner.DeleteOption(ItemOption.INTERACTION);
        }
        else
        {
            Debug.Log("���Ⱑ �����ϴ�");
        }
    }

    public override bool InteractionUpdate()
    {
        return false;
    }

}
