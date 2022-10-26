using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GimmickManager : SH.Singleton<GimmickManager>
{
    [SerializeField] private Light roomLight;
    [SerializeField] private bool isTest;


    private bool isElecEnable = false;
    private bool isLightingEnable = false;

    public bool IsElecEnable { get => isElecEnable; }
    public bool IsLightingEnable { get => isLightingEnable; }

    private string targetLayerName;
    public string TargetLayerName { get => targetLayerName; }

    private void Awake()
    {
        targetLayerName = "Item";
        if (!isTest)
        {
            targetLayerName = "LightItem";
            roomLight.enabled = false;
        }        
    }

    public void ElecEnable() => isElecEnable = true;

    public bool LightOn()
    {
        if (!isElecEnable)
            return false;

        roomLight.enabled = true;
        isLightingEnable = true;
        targetLayerName = "Item";
        return true;
    }


}
