using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InterEffectOption { OUTLINE, RIMRIGHT }

public class InteractionToRay : MonoBehaviour
{
    [SerializeField] private Renderer[] myRenderers;
    [SerializeField] private InterEffectOption interEffectOption;

    // Start is called before the first frame update
    void Awake()
    {
        myRenderers = GetComponentsInChildren<Renderer>();
       

        switch (interEffectOption)
        {
            case InterEffectOption.OUTLINE:
                foreach (var render in myRenderers)
                    render.materials[1].SetFloat("_Outline", 0f);
                break;
            case InterEffectOption.RIMRIGHT:
                foreach (var render in myRenderers)
                    render.material.SetFloat("_RimGo", 0f);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void InterationOn()
    {
        switch (interEffectOption)
        {
            case InterEffectOption.OUTLINE:
                foreach (var render in myRenderers)
                    render.materials[1].SetFloat("_Outline", 0.00262f);
                break;
            case InterEffectOption.RIMRIGHT:
                foreach (var render in myRenderers)
                    render.material.SetFloat("_RimGo", 1f);
                break;
        }
    }

    public void InterationOff()
    {
        switch (interEffectOption)
        {
            case InterEffectOption.OUTLINE:
                foreach (var render in myRenderers)
                    render.materials[1].SetFloat("_Outline", 0f);
                break;
            case InterEffectOption.RIMRIGHT:
                foreach (var render in myRenderers)
                    render.material.SetFloat("_RimGo", 0f);
                break;
        }
    }

}
