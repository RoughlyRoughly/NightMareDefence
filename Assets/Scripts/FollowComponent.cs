using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowComponent : MonoBehaviour
{
    Transform player;           //플레이어의 트랜스폼 컴포넌트를 담아둘 변수
    Vector3 offset;             //카메라와 플레이어의 간격

    [SerializeField] float smooth = 5;     //카메라가 플레이어를 뒤따라가는 시간 차이

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        offset = transform.position - player.position;
                 //카메라와 플레이어 간의 거리 간격을 구함
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + offset, smooth * Time.deltaTime);
    }
}
