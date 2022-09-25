using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnComponent : MonoBehaviour
{
    [SerializeField] float minX = 0;
    [SerializeField] float maxX = 0;
    [SerializeField] float minZ = 0;
    [SerializeField] float maxZ = 0;

    [SerializeField] GameObject[] hpItem;   //hp아이템을 담아둘 배열

    Vector3 pos;                        //아이템 생성 위치를 담아둘 변수
    Ray ray;                            //광선 담아둘 변수
    RaycastHit hit;                     //광선에 hit된 오브젝트 담아둘 변수

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
            //광선을 발사할 위치 설정

            ray.origin = pos;               //광선 발사 위치
            ray.direction = Vector3.down;   //광선 발사 방향

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
        GameObject item = null;     //선택된 아이템을 담아둘 변수

        int id = 0;

        if(id == 0)
        {
            int num = Random.Range(0, hpItem.Length);       //hp배열안에 있는 아이템 중 하나 선택
            item = hpItem[num];
        }

        Instantiate(item, SetPositon(), Quaternion.identity);   //아이템 생성
        time = 0;   //스폰 시간 초기화
    }
}
