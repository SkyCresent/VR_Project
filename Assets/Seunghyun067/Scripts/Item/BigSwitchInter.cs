using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSwitchInter : SH.Interactionable
{
    public override void Interaction()
    {
        GimmickManager.Instance.ElecEnable();

    }

    public override void UnInteraction()
    {
        Debug.Log("���Ⱑ ���Խ��ϴ�");
        GetComponent<Animator>().SetTrigger("SwitchOn");
        owner.DeleteOption(ItemOption.INTERACTION);
    }

    public override bool InteractionUpdate()
    {
        return false;
    }

}
