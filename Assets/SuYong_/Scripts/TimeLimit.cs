using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeLimit : MonoBehaviour
{
    public TextMeshProUGUI gameTimeUI;

    public float curMin;
    private float setTime;
    private int min;
    private float sec;


    private void Awake()
    {
        setTime = curMin * 60;
    }

    // Update is called once per frame
    void Update()
    {
        setTime -= Time.deltaTime;

        if (setTime >= 60f)               //남은시간이 60초보다 클 때
        {
            min = (int)setTime / 60;    //분은 남은시간을 60으로 나눠서 생긴 몫
            sec = (float)(Math.Truncate((setTime % 60) * 1) / 1);         //초는 남은시간을 60으로 나눠서 생긴 나머지
            gameTimeUI.text =  min + ":"  + sec;
        }
        if (setTime < 60)
        {
            gameTimeUI.text = setTime + "초";
        }
        if (setTime <= 0)
        {
            gameTimeUI.text = "0초";
        }
    }
}
