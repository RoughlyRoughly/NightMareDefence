using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    Rigidbody rb;           //리지드 바디 컴포넌트 담아둘 변수
    Animator anit;          //애니메이터 컴포넌트 담아둘 변수

    [SerializeField] float speed = 4;   //케릭터 이동 속도
    Vector3 movement;                   //이동 방향 저장해둘 벡터 변수

    int floorMask;                      //레이어 마스크를 담아둘 변수

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anit = GetComponent<Animator>();
        floorMask = LayerMask.GetMask("Floor");
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.i.GAMESTART || GameManager.i.GAMEOVER) return;

        float h = Input.GetAxisRaw("Horizontal");
                  //-1 또는 1을 반환 
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        Rotation();
    }
    
    void Move(float h, float v)
    {
        movement.Set(h, 0, v);          //방향 설정
        movement = movement.normalized * speed * Time.deltaTime;
        //방향 가져올 수 있도록 노말라이즈드 * 스피드 * 시간 = 방향과 크기를 설정한 벡터3 값

        rb.MovePosition(transform.position + movement);
        Animation(h, v);
    }

    void Rotation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                  //카메라에서 광선을 마우스 포인터의 위치로 쏜다
        RaycastHit hit;     //ray에 맞은 오브젝트를 담아둘 변수


        //마스크 레이어에 해당하는 물체가 레이에 맞으면 true 아니면 false
                          //광선, 맞은 물체, 광선 거리, 마스크 레이어
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, floorMask))
        {
            Vector3 dir = hit.point - transform.position;       //바라볼 방향을 구한다
            dir.y = 0;

            Quaternion rot = Quaternion.LookRotation(dir);      //회전값을 변수에 대입
            rb.MoveRotation(rot);
        }
    }

    void Animation(float h, float v)
    {
        bool isMove = h != 0 || v != 0;
        anit.SetBool("isMove", isMove);
    }
}
