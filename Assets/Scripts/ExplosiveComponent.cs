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
        //두 백터 지점간의 거리를 반환해준다

        float dmgCal = (dist / radius) * dmgRes;    //거리에 따라서 줄어든 데미지 계산
        return dmg -= (int)dmgCal;
    }
    
}
