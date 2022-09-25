using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    Rigidbody rb;           //������ �ٵ� ������Ʈ ��Ƶ� ����
    Animator anit;          //�ִϸ����� ������Ʈ ��Ƶ� ����

    [SerializeField] float speed = 4;   //�ɸ��� �̵� �ӵ�
    Vector3 movement;                   //�̵� ���� �����ص� ���� ����

    int floorMask;                      //���̾� ����ũ�� ��Ƶ� ����

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
                  //-1 �Ǵ� 1�� ��ȯ 
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        Rotation();
    }
    
    void Move(float h, float v)
    {
        movement.Set(h, 0, v);          //���� ����
        movement = movement.normalized * speed * Time.deltaTime;
        //���� ������ �� �ֵ��� �븻������� * ���ǵ� * �ð� = ����� ũ�⸦ ������ ����3 ��

        rb.MovePosition(transform.position + movement);
        Animation(h, v);
    }

    void Rotation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                  //ī�޶󿡼� ������ ���콺 �������� ��ġ�� ���
        RaycastHit hit;     //ray�� ���� ������Ʈ�� ��Ƶ� ����


        //����ũ ���̾ �ش��ϴ� ��ü�� ���̿� ������ true �ƴϸ� false
                          //����, ���� ��ü, ���� �Ÿ�, ����ũ ���̾�
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, floorMask))
        {
            Vector3 dir = hit.point - transform.position;       //�ٶ� ������ ���Ѵ�
            dir.y = 0;

            Quaternion rot = Quaternion.LookRotation(dir);      //ȸ������ ������ ����
            rb.MoveRotation(rot);
        }
    }

    void Animation(float h, float v)
    {
        bool isMove = h != 0 || v != 0;
        anit.SetBool("isMove", isMove);
    }
}
