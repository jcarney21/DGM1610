using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public int damage;
    public float timeToDie;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, timeToDie);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Move.TakeDamage(damage);
            Destroy(gameObject);


        }

        else if (other.gameObject.CompareTag("Enemy"))
        {


        }

        else if (other.gameObject.CompareTag("Ranged Enemy"))
        {




        }

        else
        {
            Destroy(gameObject);

        }

    }
}
