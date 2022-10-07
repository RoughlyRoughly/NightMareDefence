using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretComponent : MonoBehaviour
{
    GameObject target;                      //���� ������ ���� ���� ��Ƶ� ����
    [SerializeField] Transform turretHead;  //���ư� �ͷ� �Ӹ��� �Ӹ��� ��ġ�� ��Ƶ� ����
    [SerializeField] Transform shootPoint;  //�̻��� �߻�� ��ġ�� ��Ƶ� ����
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
            target = other.gameObject;  //���ʹ� Ÿ���� ������ ����ش�
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (target == other.gameObject) target = null;  //���ʹ� Ÿ���� �����
        }
    }

    void Rotatehead()
    {
        Vector3 dir = target.transform.position - transform.position;   //���� ����
        Quaternion q = Quaternion.LookRotation(dir);
        turretHead.rotation = Quaternion.Slerp(turretHead.rotation, q, Time.deltaTime * rotSpeed);
    }

    void Shoot()
    {
        GameObject temp = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        isCanAttack = false;
    }
}
