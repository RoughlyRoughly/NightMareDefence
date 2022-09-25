using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnComponent : MonoBehaviour
{
    [SerializeField] GameObject prefab;     //프리팹 에너미 오브젝트를 담아둘 변수
    [SerializeField] float spawnRate = 3;   //에너미 생성 간격

    [SerializeField] Transform[] spawnPos;  //에너미 생성 위치를 담아둘 배열


    private void Start()
    {
        InvokeRepeating("Spawn", spawnRate, spawnRate);
        //함수를 대신 호출해줌. 호출할 함수 이름, 첫 함수 호출 시간, 호출 간격
        spawnPos = GameObject.Find("SpawnPosition").GetComponentsInChildren<Transform>();
        //해당 이름의 오브젝트를 찾은 뒤 해당 오브젝트를 포함한 자식 오브젝트의 Transform 컴포넌트를
        //모두 가져와 배열에 담아줌
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        int pos = Random.Range(1, spawnPos.Length);         //에너미 생성 위치 설정
        Instantiate(prefab, spawnPos[pos].position, Quaternion.identity, transform);    //에너미 생성
    }
}
