using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public enum ControllerType { LEFT, RIGHT }
public class XRInput : SH.Singleton<XRInput>
{
    [SerializeField] XRController leftController;
    [SerializeField] XRController rightController;

    public bool GetKey(ControllerType type, InputFeatureUsage<bool> usage)
    {
        XRController xrController = type == ControllerType.LEFT ? leftController : rightController;

        if (xrController.inputDevice.TryGetFeatureValue(usage, out bool primaryButtonValueA))
        {
            return primaryButtonValueA;
        }

        return false;
    }
}
