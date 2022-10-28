using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResultText : MonoBehaviour
{
    [SerializeField] private GameObject canvers;
    [SerializeField] private GameObject resultTextObj;
    private TextMeshProUGUI resultText;
    [SerializeField] private Image fade;
    private bool isFade = false;

    public bool IsReButton = false;
    

    private void Awake()
    {
        resultText = resultTextObj.GetComponent<TextMeshProUGUI>();
    }

    public void YouDie()
    {
        CanversSetActive();
        FadeOut();
        resultText.alignment = TextAlignmentOptions.Center;
        resultText.fontSize = 17f;
        resultText.text = "You Died";
    }
    public void Escape()
    {
        FadeOut();
        CanversSetActive();
        resultText.alignment = TextAlignmentOptions.Center;
        resultText.fontSize = 17f;
        resultText.text = "Escape";
    }

    private void CanversSetActive()
    {
        if (canvers.activeSelf)
        {
            canvers.SetActive(false);
        }
        else
        {
            canvers.SetActive(true);
        }
    }

    private void Update()
    {
        
    }

    private void FadeIn()
    {
        Color c = fade.color;
        c.a = 0f;
        fade.color = c;
    }
    private void FadeOut()
    {
        StartCoroutine(FadeAlpha());
    }

    IEnumerator FadeAlpha()
    {
        float alpha = 0f;
        while (1f > alpha)
        {

            Color c = fade.color;
            c.a = alpha += Time.deltaTime;
            fade.color = c;
            Debug.Log(alpha);
            yield return null;
        }
        IsReButton = true;
    }

    private void OnEnable()
    {
        IsReButton = false;
    }
}
