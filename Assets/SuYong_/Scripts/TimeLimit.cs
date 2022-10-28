using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimeLimit : MonoBehaviour
{
    public TextMeshProUGUI gameTimeUI;

    public float curMin;
    private int min;
    private float sec;
    bool isDie = false;
    public  bool isStop = false;


    private void Awake()
    {
        GameManager.Instance.setTime = curMin * 60;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isStop)
        { 
            TimeLimi();
        }

        
    }
    public void TimeLimi()
    {
        if (GameManager.Instance.setTime >= 60f)               //남은시간이 60초보다 클 때
        {
            min = (int)GameManager.Instance.setTime / 60;    //분은 남은시간을 60으로 나눠서 생긴 몫
            sec = (float)(Math.Truncate((GameManager.Instance.setTime % 60) * 1) / 1);         //초는 남은시간을 60으로 나눠서 생긴 나머지
            gameTimeUI.text = min + ":" + sec;
        }
        if (GameManager.Instance.setTime < 60)
        {
            gameTimeUI.text = (int)GameManager.Instance.setTime + " Sec";
        }
        if (!isDie && GameManager.Instance.setTime <= 0)
        {
            TimeOver();
            gameTimeUI.text = "0 Sec";
        }
    }
    public void TimeOver()
    {
        isDie = true;
        GameManager.Instance.IsTimeGo = false;
        //폭발하고
        StartCoroutine(IsDie());
    }

    
    private IEnumerator IsDie()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.Die();
    }
}
