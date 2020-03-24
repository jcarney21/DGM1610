using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public int damage;
    public int shieldDamage;
    public float timeToDie;

    // Start is called before the first frame update
    void Start()
    {
        if (shieldDamage == 0)
        {
            shieldDamage = damage;

        }
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
            Move mv = other.gameObject.GetComponent<Move>();
            mv.TakeDamage(damage, shieldDamage);
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
