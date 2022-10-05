using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpeed : ItemComponent
{
    [SerializeField] float spd = 5.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMoveController>().GetItemSpeed(spd);
            Destroy(gameObject);
        }
    }
}
