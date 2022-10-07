using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveComponent : MonoBehaviour
{
    [SerializeField] int dmg = 50;
    [SerializeField] float dTime = 0.5f;
    [SerializeField] int dmgRes = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemycomponent>().TakeDamage(SetDamage(other.transform));
            StartCoroutine(OffCollider());
            Destroy(gameObject, dTime);
        }
    }

    IEnumerator OffCollider()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<SphereCollider>().enabled = false;
    }
     
    int SetDamage(Transform enemy)
    {
        float radius = GetComponent<SphereCollider>().radius;
        float dist = Vector3.Distance(enemy.position, transform.position);
        //�� ���� �������� �Ÿ��� ��ȯ���ش�

        float dmgCal = (dist / radius) * dmgRes;    //�Ÿ��� ���� �پ�� ������ ���
        return dmg -= (int)dmgCal;
    }
    
}
