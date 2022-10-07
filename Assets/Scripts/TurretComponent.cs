using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretComponent : MonoBehaviour
{
    GameObject target;                      //공격 범위에 들어온 적을 담아둘 변수
    [SerializeField] Transform turretHead;  //돌아갈 터렛 머리의 머리의 위치를 담아둘 변수
    [SerializeField] Transform shootPoint;  //미사일 발사될 위치를 담아둘 변수
    [SerializeField] GameObject bullet;

    [SerializeField] float dTime = 10f;

    [SerializeField] float atkRate = 0.3f;
    float t = 0;
    bool isCanAttack = true;
    float rotSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, dTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (target == null) return;

        if (other.CompareTag("Enemy"))
        {
            target = other.gameObject;  //에너미 타겟을 변수에 담아준다
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (target == other.gameObject) target = null;  //에너미 타겟을 비워줌
        }
    }

    void Rotatehead()
    {
        Vector3 dir = target.transform.position - transform.position;   //방향 설정
        Quaternion q = Quaternion.LookRotation(dir);
        turretHead.rotation = Quaternion.Slerp(turretHead.rotation, q, Time.deltaTime * rotSpeed);
    }

    void Shoot()
    {
        GameObject temp = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        isCanAttack = false;
    }
}
