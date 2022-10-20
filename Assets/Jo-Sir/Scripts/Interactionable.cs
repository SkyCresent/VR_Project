using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactionable : MonoBehaviour, IInteraction
{
    [SerializeField] private GameObject canvers;
    private Vector3 preVector3;
    public Vector3 PreVector3 { get { return preVector3; } }
    protected void Awake()
    {
        preVector3 = this.transform.position;
    }
    public virtual void Interaction()
    {
        this.gameObject.layer = 6;// 레이어 번호 확인 후 값 변경
        canvers.SetActive(true);
        // 오브젝트 위치 화면 중앙으로
        this.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0.5f);
        // 이상태일때 플레이어 인풋 바꿔주기
    }

    public virtual void UnInteraction()
    {
        this.gameObject.layer = 0;// 0은 Default
        canvers.SetActive(false);
        this.transform.position = PreVector3;
    }
}
