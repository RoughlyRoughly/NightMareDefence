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
    [SerializeField] ITEM[] slots = new ITEM[3];    //아이템 타입을 담아둘 배열
    [SerializeField] GameObject[] items;            //아이템 사용시 생성될 아이템 배열
    [SerializeField] Sprite[] itemImg;              //아이템 이미지를 담아둘 배열

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
        if (slots[id] != ITEM.NONE) return;

        if (slots[id] == ITEM.MINE)
        {

        }
    }
}
