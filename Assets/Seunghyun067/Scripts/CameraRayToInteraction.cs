using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum HandObjectState { NON_OBJECT, OBJECT }
public class CameraRayToInteraction : MonoBehaviour
{
    [SerializeField] Image imageA;
    [SerializeField] Image imageX;
    [SerializeField] Camera mainCam;
    [SerializeField] Camera subCam;
    [SerializeField] private Transform uiPoint;

    private HandObjectState curObjectState = HandObjectState.NON_OBJECT;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private LayerMask UIObjectLayer;

    [HideInInspector] public string TargetLayerName;

    private bool isInteracting = false;
    private bool isCloseUping = false;

    private GameObject curUIObject;
    private Item curObject;
    RaycastHit hit;
    private void Awake()
    {
        imageA.enabled = false;
        imageX.enabled = false;
        mainCam.enabled = true;
        subCam.enabled = false;
    }
    private void Update()
    {
        SetPosition();

        RaycastInteraction();
    }
    void SetPosition()
    {
        subCam.transform.position = mainCam.transform.position;
        subCam.transform.rotation = Quaternion.Euler(mainCam.transform.rotation.eulerAngles.x, mainCam.transform.rotation.eulerAngles.y, mainCam.transform.rotation.eulerAngles.z);
        transform.position = mainCam.transform.position;
        transform.rotation = mainCam.transform.rotation;

        Vector3 position = subCam.transform.position;
        position.y -= 0.5f;
        Vector3 dir = subCam.transform.forward;
        dir.y = 0;
        uiPoint.position = position + dir;
    }


    private void RaycastInteraction()
    {
        // ���̴� �׻� ��.
        Physics.Raycast(transform.position, transform.forward, out hit, 5f);

        Debug.DrawRay(transform.position, transform.forward * 5f, Color.red);

        // Ÿ���� ������.
        SetHoverObject();

        // Ÿ���� ���¿� ���� � �۾��� �Ұǰ� ����.
        InteractionAndCloseUpKeyDown();

        // Ÿ�ٰ��� ��ȣ�ۿ�.
        Interaction();


    }

    void SetHoverObject()
    {
        // ��ȣ�ۿ� ���� ���� ���� Ÿ���� �����ش�.  
        // �տ� ������Ʈ�� ��� ���� ���� Ÿ���� �������� �ʴ´�.
        if (isCloseUping || isInteracting || curObjectState == HandObjectState.OBJECT)
            return;

        if (!hit.transform || hit.transform.gameObject.layer 
            != LayerMask.NameToLayer(GimmickManager.Instance.TargetLayerName))
        {
            
            curObject?.GetItemComponent<Hoverable>().HoverOff();
            curObject = null;
            return;
        }

        Item targetObject = null;

        if (!(targetObject = hit.transform.GetComponent<Item>()))
            return;

        if (!targetObject.IsOption(ItemOption.HOVER))
            return;


        if (targetObject == curObject)
            return;

        curObject?.GetItemComponent<Hoverable>().HoverOff();
        curObject = targetObject;
        curObject?.GetItemComponent<Hoverable>().HoverOn();
    }

    void InteractionAndCloseUpKeyDown()
    {
        // Ÿ���� ���ų� �̹� ��ȣ�ۿ� ���̸� ������ ����.
        if (!(imageA.enabled = (curObject || isCloseUping || isInteracting)))
            return;

        // Ŭ����� �����Ѱ�?
        imageA.enabled = curObject.IsOption(ItemOption.CLOSEUP);

        // Ű�� ������ ��ȣ�ۿ�
        if (curObject.IsOption(ItemOption.INTERACTION) && curObject && Input.GetMouseButtonUp(0))
        {
            curObject?.GetItemComponent<Hoverable>().HoverOff();
            curObject.GetItemComponent<SH.Interactionable>().Interaction();
            isInteracting = true;
        }

        // Ű�� ������ Ŭ�����.
        if (imageA.enabled == true && Input.GetKeyDown(KeyCode.A))
        {
            curObject?.GetItemComponent<Hoverable>().HoverOff();
            curObject.GetItemComponent<CloseUpable>().CloseUp();
            ObjectCreate();
            MainView();
            imageA.enabled = false;
            imageX.enabled = true;
            isCloseUping = true;
        }
    }

    void Interaction()
    {
        // ��ȣ�ۿ� ���� ��..
        if (isInteracting)
        {        
            isInteracting = curObject.GetItemComponent<SH.Interactionable>().InteractionUpdate();

            // ���ο��� �����ų� Ű�� ������ ��ȣ�ۿ� ����
            if (!isInteracting || Input.GetKeyDown(KeyCode.X))
            {
                curObject.GetItemComponent<SH.Interactionable>().UnInteraction();
                InteractionEnd();
            }
        }

        // Ŭ����� ���� ��..
        if (isCloseUping)
        {
            curObject.GetItemComponent<CloseUpable>().CloseUp();

            // XŰ�� ������ Ŭ����� ����.
            if (Input.GetKeyDown(KeyCode.X))
            {
                curObject.GetItemComponent<CloseUpable>().UnCloseUp();
                InteractionEnd();
                isCloseUping = false;
            }
        }
    }

    private void InteractionEnd()
    {
        
        SubView();
        Destroy(curUIObject);
        curUIObject = null;
        imageX.enabled = false;
        curObject = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * 5f);
    }

    public void MainView()
    {
        mainCam.enabled = false;
        subCam.enabled = true;
    }
    public void SubView()
    {
        mainCam.enabled = true;
        subCam.enabled = false;
    }

    void ObjectCreate()
    {
        curUIObject = Instantiate(curObject.transform.gameObject, uiPoint.position, uiPoint.rotation);
        curUIObject.AddComponent<ObjectRotate>();
        
        //if (curObject.CloseUpLayer >= 0)
        //    curUIObject.layer = curObject.CloseUpLayer;
        //else
        //    Debug.LogError(curObject.name + "�� CloseUpLayer �ױװ� ���� ���̾� �±׿� �����ϴ�");
        
        
        if (curUIObject.GetComponent<Rigidbody>())
            curUIObject.GetComponent<Rigidbody>().useGravity = false;
    }
}