using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveController : MonoBehaviour
{
    Transform player;       //플레이어 위치를 담아둘 변수
    Rigidbody rb;

    [SerializeField] int dmg = 5;
    [SerializeField] float atkRate = 0.5f;
    bool canAttck = true;
    float t = 0;            //어택 레이트 시간 체크할 변수

    NavMeshAgent navA;      //내브메쉬에이전트를 담아둘 변수

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody>();
        navA = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if(navA.enabled)
        navA.SetDestination(player.transform.position);
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (!canAttck) return;

            collision.gameObject.GetComponent<PlayerComponent>().TakeDamage(dmg);
            StartCoroutine(AttackRate());
        }
    }

    IEnumerator AttackRate()
    {
        canAttck = false;       //공격 불가 상태로 변경
        yield return new WaitForSeconds(atkRate);
        canAttck = true;        //공격 가능 상태로 변경
    }
}
