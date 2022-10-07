using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ITEM
{
    NONE,
    MINE,
    TURRET,
    SHIELD
}

public class ItemSlotComponent : MonoBehaviour
{
    [SerializeField] ITEM[] slots = new ITEM[3];    //������ Ÿ���� ��Ƶ� �迭
    [SerializeField] GameObject[] items;            //������ ���� ������ ������ �迭
    [SerializeField] Sprite[] itemImg;              //������ �̹����� ��Ƶ� �迭

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1")) UseItem(0);
        else if (Input.GetKeyDown("2")) UseItem(1);
        else if (Input.GetKeyDown("3")) UseItem(2);
    }

    void UseItem(int id)
    {
        if (slots[id] == ITEM.NONE) return;

        if (slots[id] == ITEM.MINE)
        {
            Instantiate(items[(int)slots[id] - 1], transform.position, Quaternion.identity);
        }

        slots[id] = ITEM.NONE;
        UIManager.i.SetSlotUI(ITEM.NONE, id);
    }

    public void GetItem(ITEM type, string name,int imgidx)
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == ITEM.NONE)
            {
                slots[i] = type;
                UIManager.i.SetSlotUI(type, i, name, itemImg[imgidx]);
                break;
            }
        }
    }
}
