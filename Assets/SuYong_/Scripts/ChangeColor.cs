using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public List<Color> butColors = new List<Color>();
    public Button button;
    private int count;

    private void Start()
    {
        butColors.Add(Color.white);
        butColors.Add(Color.red);
        butColors.Add(Color.yellow);
        butColors.Add(Color.blue);
        butColors.Add(Color.green);

        button.image.color = butColors[0];
    }

    public void ChangeButtonColor()
    {


        if (button.image.color == butColors[count])
        {
            if (count == 4)
            {
                count = 0;
                button.image.color = butColors[count];
            }
            else
            {
                count++;
                button.image.color = butColors[count];

            }
        }
        

    }
}
