using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectile : MonoBehaviour
{
    public int antiEnemyDamage;
    public float timeToDie;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDie);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
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
