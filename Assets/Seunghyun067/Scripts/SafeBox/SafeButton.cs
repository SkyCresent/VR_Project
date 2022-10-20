using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeButton : MonoBehaviour
{
    [SerializeField] private SafeButtonType type;
    public SafeButtonType ButtonType { get => type; }    
}
