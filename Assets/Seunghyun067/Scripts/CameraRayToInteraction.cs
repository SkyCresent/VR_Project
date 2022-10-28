using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;



public enum HandObjectState { NON_OBJECT, OBJECT }
public class CameraRayToInteraction : MonoBehaviour
{
    [SerializeField] private GameObject move;
    [SerializeField] private LineRenderer line;
    [SerializeField] public Image imageA;
    [SerializeField] public Image imageX;
    [SerializeField] public Image handImage;
    [SerializeField] public Camera mainCam;
    [SerializeField] public Camera subCam;
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
    private Item curHoverL;
    private Item curHoverR;
    RaycastHit hitL;
    RaycastHit hitR;
    private void Awake()
    {
        imageA.enabled = false;
        imageX.enabled = false;
        //handImage.enabled = false;
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
        // subCam.transform.position = mainCam.transform.position;
        // subCam.transform.rotation = Quaternion.Euler(mainCam.transform.rotation.eulerAngles.x, mainCam.transform.rotation.eulerAngles.y, mainCam.transform.rotation.eulerAngles.z);
        // transform.position = mainCam.transform.position;
        // transform.rotation = mainCam.transform.rotation;
        // 
        // Vector3 position = subCam.transform.position;
        // position.y -= 0.5f;
        // Vector3 dir = subCam.transform.forward;
        // dir.y = 0;
        //uiPoint.position = position + dir;
    }

    private void RaycastInteraction()
    {
        if (curObject)
            Debug.Log(curObject.name);

        // 레이는 항상 쏨.
        Physics.Raycast(GimmickManager.Instance.LController.transform.position, GimmickManager.Instance.LController.transform.forward, out hitL, 1);
        Physics.Raycast(GimmickManager.Instance.RController.transform.position, GimmickManager.Instance.RController.transform.forward, out hitR, 1);



        // 타겟을 정해줌.
        SetHoverObjectL(hitL);
        SetHoverObjectR(hitR);
        //SetHoverObject(hitR, curHoverR);

        // 타겟의 상태에 따라 어떤 작업을 할건가 결정.
        InteractionAndCloseUpKeyDown(ControllerType.LEFT, curHoverL);
        InteractionAndCloseUpKeyDown(ControllerType.RIGHT, curHoverR);
        //InteractionAndCloseUpKeyDown();

        // 타겟과의 상호작용.
        Interaction();

        TestInput();
    }

    void TestInput()
    {

    }

    void SetHoverObjectL(RaycastHit _hit)
    {
        // 상호작용 하지 않을 때만 타겟을 정해준다.  
        // 손에 오브젝트를 들고 있을 때도 타겟을 정해주지 않는다.
        if (isCloseUping || isInteracting || curObjectState == HandObjectState.OBJECT)
            return;

        if (!_hit.transform || _hit.transform.gameObject.layer
            != LayerMask.NameToLayer(GimmickManager.Instance.TargetLayerName))
        {

            curHoverL?.GetItemComponent<Hoverable>().HoverOff();
            curHoverL = null;
            return;
        }

        Item targetObject = null;

        if (!(targetObject = _hit.transform.GetComponent<Item>()))
            return;

        if (!targetObject.IsOption(ItemOption.HOVER))
            return;


        if (targetObject == curHoverL)
            return;

        curHoverL?.GetItemComponent<Hoverable>().HoverOff();
        curHoverL = targetObject;
        curHoverL?.GetItemComponent<Hoverable>().HoverOn();
    }

    void SetHoverObjectR(RaycastHit _hit)
    {
        // 상호작용 하지 않을 때만 타겟을 정해준다.  
        // 손에 오브젝트를 들고 있을 때도 타겟을 정해주지 않는다.
        if (isCloseUping || isInteracting || curObjectState == HandObjectState.OBJECT)
            return;

        if (!_hit.transform || _hit.transform.gameObject.layer
            != LayerMask.NameToLayer(GimmickManager.Instance.TargetLayerName))
        {

            curHoverR?.GetItemComponent<Hoverable>().HoverOff();
            curHoverR = null;
            return;
        }

        Item targetObject = null;

        if (!(targetObject = _hit.transform.GetComponent<Item>()))
            return;

        if (!targetObject.IsOption(ItemOption.HOVER))
            return;


        if (targetObject == curHoverR)
            return;

        curHoverR?.GetItemComponent<Hoverable>().HoverOff();
        curHoverR = targetObject;
        curHoverR?.GetItemComponent<Hoverable>().HoverOn();
    }

    void InteractionAndCloseUpKeyDown(ControllerType type, Item curHover)
    {
        if (isCloseUping)
            return;

        if (isInteracting)
            return;

        // 타겟이 없거나 이미 상호작용 중이면 들어오지 않음.
        if (!(imageA.enabled = curHover))
            return;

        // 클로즈업 가능한가?
        //imageA.enabled = ;

        if (curHover.IsOption(ItemOption.INTERACTION))
            Debug.Log("Option");

        if (curHover.IsOption(ItemOption.CLOSEUP) == true && (XRInput.Instance.GetKey(ControllerType.LEFT, CommonUsages.primaryButton) || XRInput.Instance.GetKey(ControllerType.RIGHT, CommonUsages.primaryButton)))
        {
            curObject = curHover;
            curObject?.GetItemComponent<Hoverable>().HoverOff();
            curObject.GetItemComponent<CloseUpable>().CloseUp();
            ObjectCreate();
            MainView();
            imageA.enabled = false;
            imageX.enabled = true;
            isCloseUping = true;
            move.SetActive(false);
        }

        // 키를 눌러서 상호작용
        else if (curHover.IsOption(ItemOption.INTERACTION) && (XRInput.Instance.GetKey(ControllerType.LEFT, CommonUsages.primaryButton) || XRInput.Instance.GetKey(ControllerType.RIGHT, CommonUsages.primaryButton)))
        {
            curObject = curHover;
            Debug.Log("asd");
            curObject?.GetItemComponent<Hoverable>().HoverOff();
            curObject.GetItemComponent<SH.Interactionable>().Interaction();
            isInteracting = true;
        }

        // 키를 눌러서 클로즈업.
        
    }

    void Interaction()
    {
        // 상호작용 진행 중..
        if (isInteracting)
        {
            isInteracting = curObject.GetItemComponent<SH.Interactionable>().InteractionUpdate();

            // 내부에서 끝나거나 키를 누르면 상호작용 종료
            if (!isInteracting || XRInput.Instance.GetKey(ControllerType.LEFT, CommonUsages.secondaryButton) || XRInput.Instance.GetKey(ControllerType.RIGHT, CommonUsages.secondaryButton))
            {
                curObject.GetItemComponent<SH.Interactionable>().UnInteraction();
                InteractionEnd();
            }
        }

        // 클로즈업 진행 중..
        if (isCloseUping)
        {
            curObject.GetItemComponent<CloseUpable>().CloseUp();

            // X키를 누르면 클로즈업 종료.
            if (XRInput.Instance.GetKey(ControllerType.LEFT, CommonUsages.secondaryButton) || XRInput.Instance.GetKey(ControllerType.RIGHT, CommonUsages.secondaryButton))
            {
                curObject.GetItemComponent<CloseUpable>().UnCloseUp();
                InteractionEnd();
                isCloseUping = false;
                move.SetActive(true);
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
        Vector3 UiPos = uiPoint.position;
        UiPos.x += curObject.GetItemComponent<CloseUpable>().OffsetX;
        UiPos.y += curObject.GetItemComponent<CloseUpable>().OffsetY;

        curUIObject = Instantiate(curObject.transform.gameObject, uiPoint.position, uiPoint.rotation);
        curUIObject.AddComponent<ObjectRotate>();

        if (curUIObject.GetComponent<Rigidbody>())
            curUIObject.GetComponent<Rigidbody>().useGravity = false;
    }
}