using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform target;
    public int damage;
    public float moveSpeed;
    public float enemyHealth;
    // Another Option is to set target as GameObject

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        target = GameObject.FindWithTag("Player").transform;


        if (enemyHealth < 1)
        {
            Destroy(gameObject);

        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            enemyHealth = enemyHealth - 25;


        }

    }
}
