using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{

    private Rigidbody bulletRigidbody;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        float speed = 20f; 
        bulletRigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyBehaviour enemy = other.GetComponent<EnemyBehaviour>();
            
            if (enemy != null)
            {
                enemy.TakeDamage(25f);
            }
        }

        Destroy(gameObject);    
    }
}
