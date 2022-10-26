using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractionable : MonoBehaviour,IInteraction
{
    // Start is called before the first frame update

    Button btn;

    void Start()
    {
        btn = GetComponent<Button>();
    }

    public void Interaction()
    {
        btn.onClick?.Invoke();
    }
    public void UnInteraction()
    {

    }
}
