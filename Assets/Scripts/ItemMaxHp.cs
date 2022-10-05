using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMaxHp : ItemComponent
{
    [SerializeField] int maxHp = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerComponent>().GetItemMaxHp(maxHp);
            Destroy(gameObject);
        }
    }
}
