using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCritical : ItemComponent
{
    [SerializeField] float cri = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInChildren<ShootComponent>().GetItemCritical(cri);
            Destroy(gameObject);
        }
    }
}
