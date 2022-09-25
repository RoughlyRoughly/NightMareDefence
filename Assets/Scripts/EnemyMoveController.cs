using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveController : MonoBehaviour
{
    Transform player;       //�÷��̾� ��ġ�� ��Ƶ� ����
    Rigidbody rb;

    [SerializeField] int dmg = 5;
    [SerializeField] float atkRate = 0.5f;
    bool canAttck = true;
    float t = 0;            //���� ����Ʈ �ð� üũ�� ����

    NavMeshAgent navA;      //����޽�������Ʈ�� ��Ƶ� ����

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
        canAttck = false;       //���� �Ұ� ���·� ����
        yield return new WaitForSeconds(atkRate);
        canAttck = true;        //���� ���� ���·� ����
    }
}
