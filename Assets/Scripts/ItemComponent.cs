using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemComponent : MonoBehaviour
{
    [SerializeField] float dTime = 7;       //아이템이 생성된 후 삭제되는 시간

    float rot = 0;
    float rotSpeed = 150;

    // Start is called before the first frame update
    public virtual void Start()
    {
        Destroy(gameObject, dTime); //게임 오브젝트 아이템 삭제 함수 호출
    }

    // Update is called once per frame
    void Update()
    {
        RotateItem();
    }

    void RotateItem()
    {
        //아이템 회전
        transform.GetChild(0).rotation = Quaternion.Euler(0, rot += Time.deltaTime * rotSpeed, 0);
    }

}
