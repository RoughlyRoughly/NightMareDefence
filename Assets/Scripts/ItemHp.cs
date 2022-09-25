using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHp : ItemComponent
{
    [SerializeField] public int hp = 5;

    public override void Start()
    {
        base.Start();
        GetComponentInChildren<TextMesh>().text = "HP+"+hp.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerComponent>().GetItemHp(hp);
            Destroy(gameObject);
        }
    }
}
