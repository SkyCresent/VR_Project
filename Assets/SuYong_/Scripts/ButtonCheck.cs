using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonCheck : MonoBehaviour
{
    public Button[] button = null;
    public bool isChecked;

    public void Checking()
    {
        if(button != null)
        {
            if (button[0].image.color == Color.red && button[1].image.color == Color.yellow
                && button[2].image.color == Color.blue && button[3].image.color == Color.green)
            {
                isChecked = true;
            }
            else
            {
                isChecked = false;
            }
        }
    }
}
