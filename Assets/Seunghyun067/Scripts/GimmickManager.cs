using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.XR;

public class GimmickManager : SH.Singleton<GimmickManager>
{
    [SerializeField] private Light[] roomLights;
    [SerializeField] private Renderer[] lightRenderers;
    [SerializeField] private bool isTest;
    [SerializeField] public GameObject LController;
    [SerializeField] public GameObject RController;

    [SerializeField] private GameObject dice;

    private bool isElecEnable = false;
    private bool isLightingEnable = false;

    public bool IsElecEnable { get => isElecEnable; }
    public bool IsLightingEnable { get => isLightingEnable; }

    private string targetLayerName;
    public string TargetLayerName { get => targetLayerName; }

    [SerializeField]
    private GameObject L_line;
    [SerializeField]
    private GameObject R_line;

    private void Awake()
    {
        //L_line.SetActive(false);
        //R_line.SetActive(false);
        targetLayerName = "Item";

        

        if (!isTest)
        {
            targetLayerName = "LightItem";
            dice.SetActive(false);
            for (int i = 0; i < roomLights.Length; i++)
            {
                roomLights[i].enabled = false;
                lightRenderers[i].material.SetColor("_EmissionColor", Color.black);
                
            }
        }
    }

    public void ElecEnable() => isElecEnable = true;

    public bool LightOn()
    {
        if (!isElecEnable)
            return false;

        dice.SetActive(true);
        for (int i = 0; i < roomLights.Length; i++)
        {
            roomLights[i].enabled = true;
            lightRenderers[i].material.SetColor("_EmissionColor", Color.white);
            
        }
        isLightingEnable = true;
        targetLayerName = "Item";
        return true;
    }

    public void L_LineOnOff(bool isEnable) => L_line.SetActive(isEnable);
    public void R_LineOnOff(bool isEnable) => R_line.SetActive(isEnable);

}
