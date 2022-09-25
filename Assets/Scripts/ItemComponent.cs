using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemComponent : MonoBehaviour
{
    [SerializeField] float dTime = 7;       //�������� ������ �� �����Ǵ� �ð�

    float rot = 0;
    float rotSpeed = 150;

    // Start is called before the first frame update
    public virtual void Start()
    {
        Destroy(gameObject, dTime); //���� ������Ʈ ������ ���� �Լ� ȣ��
    }

    // Update is called once per frame
    void Update()
    {
        RotateItem();
    }

    void RotateItem()
    {
        //������ ȸ��
        transform.GetChild(0).rotation = Quaternion.Euler(0, rot += Time.deltaTime * rotSpeed, 0);
    }

}
