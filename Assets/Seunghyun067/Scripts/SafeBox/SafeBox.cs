using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public enum SafeButtonType { NUMBER, ENTER, DELETE }

[RequireComponent(typeof(Animator))]

public class SafeBox : MonoBehaviour
{
    [Header("SafeBox Option")]
    [SerializeField] private string passwordInput;
    [SerializeField] private LayerMask numberLayer;
    [SerializeField] private LayerMask safeLayer;
    [SerializeField] private Mesh[] numberMeshs;
    [SerializeField] private List<MeshFilter> passwordMesh = new List<MeshFilter>();
    [SerializeField] private GameObject open;
    [SerializeField] private GameObject close;
    [SerializeField] private Camera mainCam;
    [SerializeField] private GameObject point;
    private GameObject point2;

    private Camera safeCam;

    private List<int> resultPassword = new List<int>();
    private List<int> curPassword = new List<int>();

    private Animator animator;

    private void Awake()
    {
        point2 = Instantiate(point);
        foreach (var pass in passwordInput)
            resultPassword.Add(pass - '0');

        foreach (var pass in passwordMesh)
            pass.mesh = null;

        animator = GetComponent<Animator>();

        foreach (var openRender in open.GetComponentsInChildren<Renderer>())
            openRender.material.color = Color.blue;
        foreach (var closeRender in close.GetComponentsInChildren<Renderer>())
            closeRender.material.color = Color.blue;

        safeCam = GetComponentInChildren<Camera>();
        safeCam.enabled = false;


    }

    private void PrintPassword()
    {
        string curPW = "CurPassword : ";
        foreach (var p in curPassword)
            curPW += p + " ";
    }

    private void NumberMeshUpdate()
    {
        foreach (var pass in passwordMesh)
            pass.mesh = null;

        for (int i = 0; i < curPassword.Count; ++i)
            passwordMesh[curPassword.Count - i - 1].mesh = numberMeshs[curPassword[i]];
    }

    private void Number(int number)
    {
        if (curPassword.Count == 5)
        {
            SetPassword();
            PrintPassword();
            Music.Instance.PlaySound("error_sound");
            return;
        }

        curPassword.Add(number);
        NumberMeshUpdate();
        PrintPassword();
        Music.Instance.PlaySound("input_password_sound(3)");
    }

    private void Enter()
    {
        if (resultPassword.Count != curPassword.Count)
        {
            SetPassword();
            PrintPassword();
            Music.Instance.PlaySound("error_sound");
            return;
        }

        for (int i = 0; i < resultPassword.Count; ++i)
        {
            if (resultPassword[i] != curPassword[i])
            {
                SetPassword();
                PrintPassword();
                return;
            }
        }

        foreach (var openRender in open.GetComponentsInChildren<Renderer>())
            openRender.material.color = Color.blue * 10f;
        SetPassword();
        animator.SetBool("Open", true);
        StartCoroutine(co());
    }

    IEnumerator co()
    {
        yield return new WaitForSeconds(3f);
        foreach (var openRender in open.GetComponentsInChildren<Renderer>())
            openRender.material.color = Color.blue;
        foreach (var closeRender in close.GetComponentsInChildren<Renderer>())
            closeRender.material.color = Color.blue * 10f;
        yield return new WaitForSeconds(1f);
        foreach (var closeRender in close.GetComponentsInChildren<Renderer>())
            closeRender.material.color = Color.blue;

    }

    private void Delete()
    {
        if (curPassword.Count == 0)
            return;

        curPassword.RemoveAt(curPassword.Count - 1);
        NumberMeshUpdate();
        PrintPassword();
    }

    private void SetPassword()
    {
        curPassword.Clear();
        foreach (var pass in passwordMesh)
            pass.mesh = null;
        
    }

    int keyCount = 0;
    int keyCount2 = 0;

    private void Update()
    {
        Ray(ControllerType.LEFT);
        Ray(ControllerType.RIGHT);
    }

    public void Ray(ControllerType type)
    {
        GameObject curController = type == ControllerType.LEFT ? GimmickManager.Instance.LController : GimmickManager.Instance.RController;
        GameObject curPoint = type == ControllerType.LEFT ? point : point2;

        RaycastHit hit;
        curPoint.SetActive(false);
        Physics.Raycast(curController.transform.position, curController.transform.forward, out hit, 1, safeLayer);


        curPoint.transform.position = hit.point;

        bool isRay = Physics.Raycast(curController.transform.position, curController.transform.forward, out hit, 1, numberLayer);

        if (!isRay)
            return;
        curPoint.SetActive(true);
        curPoint.transform.position = hit.point;

        SafeButton button = hit.transform.GetComponent<SafeButton>();
        Debug.Log(hit.transform.gameObject.name);
        if (null == button)
            return;

        if (!XRInput.Instance.GetKey(type, CommonUsages.primaryButton))
        {
            if (type == ControllerType.LEFT)
                keyCount = 0;
            else
                keyCount2 = 0;
            return;
        }

        if (type == ControllerType.LEFT)
        {

            if (++keyCount != 1)
                return;
        }
        else
        {

            if (++keyCount2 != 1)
                return;
        }

       


        switch (button.ButtonType)
        {
            case SafeButtonType.NUMBER:
                Number(hit.transform.name[0] - '0');
                break;
            case SafeButtonType.ENTER:
                Enter();
                break;
            case SafeButtonType.DELETE:
                Delete();
                break;
            default:
                break;
        }
    }
}
