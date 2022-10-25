using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayserPointer : MonoBehaviour
{
    private LineRenderer layser;         //보이는 레이저
    private RaycastHit collidedObject;   //충돌된 객체
    private GameObject currentObject;    //최근에 충돌한 객체를 저장하기 위한 객체

    public float raycastDistance = 100f; //레이저 포인터 감지 거리 임시로 100 설정

    // Start is called before the first frame update
    void Start()
    {
        //이 스크립트 포함된 객체에 LineRenderer 컴포넌트 추가
        layser = this.gameObject.AddComponent<LineRenderer>();

        Material material = new Material(Shader.Find("Standard"));
        material.color = new Color(0, 195, 225, 0.5f);
        layser.material = material;

        layser.positionCount = 2;

        //레이저 굵기 임시 설정
        layser.startWidth = 0.01f;
        layser.endWidth = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        layser.SetPosition(0, transform.position); //첫번째 시작점 위치, 업뎃에 넣어 플레이어 이동시 따라 이동
        Debug.DrawRay(transform.position, transform.forward, Color.green, 0.5f);

        //충돌감지
        if (Physics.Raycast(transform.position, transform.forward, out collidedObject, raycastDistance))
        {
            layser.SetPosition(1, collidedObject.point);

            if (collidedObject.collider.gameObject.CompareTag("Button"))
            {
                if (Input.GetKeyDown(KeyCode.Space))    // 컨트롤러로 입력할 키로 변경해야함
                {
                    collidedObject.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                }
                else
                {
                    collidedObject.collider.gameObject.GetComponent<Button>().OnPointerEnter(null);
                    currentObject = collidedObject.collider.gameObject;
                }
            }
        }

        else
        {
            //레이저에 감지된 것이 없어 초기 설정 길이만큼 길게 표현
            layser.SetPosition(1, transform.position + (transform.forward * raycastDistance));

            if (currentObject != null)
            {
                //최근 감지된 오브젝트가 button인 경우
                //버튼은 현재 눌려있는 상태이므로 풀어줌
                currentObject.GetComponent<Button>().OnPointerExit(null);
                currentObject = null;
            }
        }
    }


    private void LateUpdate()
    {
        //버튼을 누를 경우
        /*if(OVRInput.GetDown(OVRInput.Button.One))
        {
            layser.material.color = new Color(255, 255, 255, 0.5f);
        }

        //버튼을 뗄 경우
        else if (OVRInput.GetUp(OVRInput.Button.One))
        {
            layser.material.color = new Color(0, 195, 225, 0.5f);
        }*/
    }
}
