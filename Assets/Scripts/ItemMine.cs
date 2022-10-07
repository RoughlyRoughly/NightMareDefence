using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMine : ItemComponent
{
    [SerializeField] ITEM item;
    [SerializeField] int id;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<ItemSlotComponent>().GetItem(item, "MINE", id);
            Destroy(gameObject);
        }
        
    }
}
