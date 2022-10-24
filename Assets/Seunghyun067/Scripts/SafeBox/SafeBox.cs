using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SafeButtonType { NUMBER, ENTER, DELETE }

[RequireComponent(typeof(Animator))]

public class SafeBox : MonoBehaviour
{
    [SerializeField] private string passwordInput;
    [SerializeField] private LayerMask numberLayer;
    [SerializeField] private Mesh[] numberMeshs;
    [SerializeField] private List<MeshFilter> passwordMesh = new List<MeshFilter>();
    [SerializeField] private GameObject open;
    [SerializeField] private GameObject close;

    private List<int> resultPassword = new List<int>();
    private List<int> curPassword = new List<int>();

    private Animator animator;

    private void Awake()
    {
        foreach (var pass in passwordInput)
            resultPassword.Add(pass - '0');

        foreach (var pass in passwordMesh)
            pass.mesh = null;

        animator = GetComponent<Animator>();

        foreach (var openRender in open.GetComponentsInChildren<Renderer>())
            openRender.material.color = Color.blue;
        foreach (var closeRender in close.GetComponentsInChildren<Renderer>())
            closeRender.material.color = Color.blue;


    }

    private void Update()
    {
        //if (!Input.GetMouseButtonDown(0)) return;
        //
        //RaycastHit hit;
        //
        //if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, int.MaxValue, numberLayer))
        //{
        //    SafeButton button = hit.transform.GetComponent<SafeButton>();
        //
        //    switch (button.ButtonType)
        //    {
        //        case SafeButtonType.NUMBER:
        //            Number(hit.transform.name[0] - '0');
        //            break;
        //        case SafeButtonType.ENTER:
        //            Enter();
        //            break;
        //        case SafeButtonType.DELETE:
        //            Delete();
        //            break;
        //        default:
        //            break;
        //    }
        //}
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

            return;
        }

        curPassword.Add(number);
        NumberMeshUpdate();
        PrintPassword();
    }

    private void Enter()
    {
        if (resultPassword.Count != curPassword.Count)
        {
            SetPassword();
            PrintPassword();
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
        animator.SetBool("Open", false);
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
}