using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnComponent : MonoBehaviour
{
    [SerializeField] GameObject prefab;     //������ ���ʹ� ������Ʈ�� ��Ƶ� ����
    [SerializeField] float spawnRate = 3;   //���ʹ� ���� ����

    [SerializeField] Transform[] spawnPos;  //���ʹ� ���� ��ġ�� ��Ƶ� �迭


    private void Start()
    {
        InvokeRepeating("Spawn", spawnRate, spawnRate);
        //�Լ��� ��� ȣ������. ȣ���� �Լ� �̸�, ù �Լ� ȣ�� �ð�, ȣ�� ����
        spawnPos = GameObject.Find("SpawnPosition").GetComponentsInChildren<Transform>();
        //�ش� �̸��� ������Ʈ�� ã�� �� �ش� ������Ʈ�� ������ �ڽ� ������Ʈ�� Transform ������Ʈ��
        //��� ������ �迭�� �����
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        int pos = Random.Range(1, spawnPos.Length);         //���ʹ� ���� ��ġ ����
        Instantiate(prefab, spawnPos[pos].position, Quaternion.identity, transform);    //���ʹ� ����
    }
}
