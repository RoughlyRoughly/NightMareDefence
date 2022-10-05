using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAttackSpeed : ItemComponent
{
    [SerializeField] float rate = 0.02f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInChildren<ShootComponent>().GetItemAttackSpeed(rate);
            Destroy(gameObject);
        }
    }
}
