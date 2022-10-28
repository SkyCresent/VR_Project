using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : SH.Singleton<GameManager>
{
    private ResultText resultText;
    private TimeLimit timeLimit;
    [SerializeField] private GameObject watchUI;
    [SerializeField] private GameObject[] dices;
    [SerializeField] private GameObject[] keys;
    [SerializeField] private Animator doorAni;
    [SerializeField] private GameObject explosion;
    
    [HideInInspector] public float setTime;

    private AudioSource tictokSound;

    private bool isTimeGo = true;
    public bool IsTimeGo 
    { 
        get => isTimeGo;

        set
        {
            isTimeGo = value;
            if (value)
                tictokSound.Play();
            else
                tictokSound.Stop();
        }
    }

    private void Awake()
    {
        resultText = GetComponent<ResultText>();
        timeLimit = GetComponent<TimeLimit>();
       
        tictokSound = GetComponent<AudioSource>();
    }

    private void Start()
    {
        Music.Instance.PlaySound("basement_ambience");

        Invoke("StartSound", 2f);
        
    }

    public void StartSound()
    {
        Music.Instance.PlaySound("Sawlaughing");
    }
    


    public void TimeStopSound(bool isGo)
    {
        if (isGo)
            tictokSound.Play();
        else
            tictokSound.Stop();
    }

    private void Update()
    {
        if (isTimeGo)
            setTime -= Time.deltaTime;



        if (Input.GetKeyDown(KeyCode.F))
        { Die(); }

        if (!resultText.IsReButton)
            return;

        if (XRInput.Instance.GetKey(ControllerType.LEFT, CommonUsages.secondaryButton))
        {
            // re
            resultText.IsReButton = false;
            SceneManager.LoadScene("MainScene");

        }
        else if (XRInput.Instance.GetKey(ControllerType.RIGHT, CommonUsages.secondaryButton))
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
    public void Die()
    {
        explosion.SetActive(true);
        StartCoroutine(DieWait());
        StartCoroutine(Exp());
    }

    IEnumerator Exp()
    {
        int count = 4;

        while(count-- > 0)
        {
            Music.Instance.PlaySound("Explosion");
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator DieWait()
    {
        yield return new WaitForSeconds(1f);
        resultText.YouDie();
    }

    public void DiceOnAble()
    {
        foreach (var dice in dices)
        {
            dice.SetActive(true);
        }
        Music.Instance.PlaySound("Dice");


    }

    public void KeyOnAble()
    {
        foreach (var key in keys)
        {
            key.transform.SetParent(null);
            key.SetActive(true);
            key.GetComponent<Rigidbody>().isKinematic = false;
        }
        Music.Instance.PlaySound("KeyGing");
        timeLimit.isStop = true;
    }

    public void InsertKey()
    {
        GameManager.Instance.IsTimeGo = true;
        timeLimit.isStop = false;
        Music.Instance.PlaySound("KeyGing");
        doorAni.Play("DoorOpen");
        Invoke("Sawlaughing", 2f);
        watchUI.SetActive(true);
        setTime = 5f;
    }

    public void Sawlaughing()
    {
        Music.Instance.PlaySound("startSaw");
    }
}

