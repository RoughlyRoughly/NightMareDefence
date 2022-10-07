using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float speed = 3;
    [SerializeField] GameObject fx;
    [SerializeField] float dTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, dTime);
    }

    public void Move(Vector3 dir)
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = dir * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Instantiate(fx, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
