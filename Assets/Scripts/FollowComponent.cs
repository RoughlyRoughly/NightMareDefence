using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowComponent : MonoBehaviour
{
    Transform player;           //�÷��̾��� Ʈ������ ������Ʈ�� ��Ƶ� ����
    Vector3 offset;             //ī�޶�� �÷��̾��� ����

    [SerializeField] float smooth = 5;     //ī�޶� �÷��̾ �ڵ��󰡴� �ð� ����

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        offset = transform.position - player.position;
                 //ī�޶�� �÷��̾� ���� �Ÿ� ������ ����
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + offset, smooth * Time.deltaTime);
    }
}
