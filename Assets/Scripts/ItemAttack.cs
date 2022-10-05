using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAttack : ItemComponent
{
    [SerializeField] int dmg = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInChildren<ShootComponent>().GetAttackItem(dmg);
            Destroy(gameObject);
        }
    }
}
