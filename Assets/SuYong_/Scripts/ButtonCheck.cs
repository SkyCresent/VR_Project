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
        if(button != null&& !isChecked)
        {
            if (button[0].image.color == Color.red && button[1].image.color == Color.blue
                && button[2].image.color == Color.yellow && button[3].image.color == Color.green)
            {
                isChecked = true;
                GameManager.Instance.KeyOnAble();
                GameManager.Instance.IsTimeGo = false;
                
            }
            else
            {
                isChecked = false;
            }
        }
    }
}
