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

    public XRController LeftController { get => leftController; }
    public XRController RightController { get => rightController; }

    public bool GetKey(ControllerType type, InputFeatureUsage<bool> usage)
    {
        XRController xrController = type == ControllerType.LEFT ? leftController : rightController;
        if (xrController.inputDevice.TryGetFeatureValue(usage, out bool primaryButtonValueA))
        {
            return primaryButtonValueA;
        }

        return false;
    }

    public Vector2 JoySick(ControllerType type)
    {
        XRController xrController = type == ControllerType.LEFT ? leftController : rightController;

        if (LeftController.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
        {
            return position;
        }
        return Vector2.zero;
    }
}
