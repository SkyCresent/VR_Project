using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseUpable : ItemComponent, ICloseUp
{
    [SerializeField] private string closeUpLayer = "Default";
    public int CloseUpLayer { get => LayerMask.NameToLayer(closeUpLayer); }

    private GameObject UIObject;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 scale;
    [SerializeField] private float rotSpeed;

    protected void Awake()
    {
        base.Init(ItemOption.CLOSEUP);

        //UIObject = Instantiate(gameObject, Vector3.zero, transform.rotation);
        //UIObject.AddComponent<ObjectRotate>();
        //
        //if (closeUpLayer.Length == 0)
        //    closeUpLayer = "Default";
    }
    public virtual void CloseUp()
    {
        // Vector3 pos = Camera.main.transform.position;
        // Vector3 dir = Camera.main.transform.forward;
        // UIObject.SetActive(true);
        // dir.y = 0;
        // pos += dir * 1f;
        // UIObject.transform.position = pos;
        // UIObject.transform.rotation = transform.rotation;
        // 
        // //if (curObject.CloseUpLayer >= 0)
        // //    curUIObject.layer = curObject.CloseUpLayer;
        // //else
        // //    Debug.LogError(curObject.name + "의 CloseUpLayer 테그가 현재 레이어 태그에 없습니다");
        // 
        // 
        // if (UIObject.GetComponent<Rigidbody>())
        //     UIObject.GetComponent<Rigidbody>().useGravity = false;
    }

    public virtual void UnCloseUp()
    {
        UIObject.SetActive(false);
    }

    public virtual void CloseUpUpdate()
    {
        // if (Input.GetMouseButton(0))
        // {
        //     transform.Rotate(0f, -Input.GetAxis("Mouse X") * 3, 0f, Space.World);
        //     transform.Rotate(Input.GetAxis("Mouse Y") * 3, 0f, 0f);
        // }
    }
}