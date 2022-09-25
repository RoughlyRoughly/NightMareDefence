using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnComponent : MonoBehaviour
{
    [SerializeField] float minX = 0;
    [SerializeField] float maxX = 0;
    [SerializeField] float minZ = 0;
    [SerializeField] float maxZ = 0;

    [SerializeField] GameObject[] hpItem;   //hp�������� ��Ƶ� �迭

    Vector3 pos;                        //������ ���� ��ġ�� ��Ƶ� ����
    Ray ray;                            //���� ��Ƶ� ����
    RaycastHit hit;                     //������ hit�� ������Ʈ ��Ƶ� ����

    [SerializeField] float spawnRate = 7;
    float time = 0;
    

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= spawnRate)
        {
            SpawnItem();
        }
    }

    Vector3 SetPositon()
    {
        while(true)
        {
            pos = new Vector3(Random.Range(minX, maxX), 10, Random.Range(minZ, maxZ));
            //������ �߻��� ��ġ ����

            ray.origin = pos;               //���� �߻� ��ġ
            ray.direction = Vector3.down;   //���� �߻� ����

            if(Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Floor")) break;
                else continue;
            }          
        }

        return hit.point;
    }

    void SpawnItem()
    {
        GameObject item = null;     //���õ� �������� ��Ƶ� ����

        int id = 0;

        if(id == 0)
        {
            int num = Random.Range(0, hpItem.Length);       //hp�迭�ȿ� �ִ� ������ �� �ϳ� ����
            item = hpItem[num];
        }

        Instantiate(item, SetPositon(), Quaternion.identity);   //������ ����
        time = 0;   //���� �ð� �ʱ�ȭ
    }
}
