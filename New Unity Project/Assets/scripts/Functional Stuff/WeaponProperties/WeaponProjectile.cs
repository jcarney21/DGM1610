﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectile : MonoBehaviour
{
    //public Transform enemy;
    //public Transform rangedEnemy;
    //public Transform player;

    public int damage;
    public int shieldDamage;
    public float timeToDie;
    public float velocity;
    public float range;
    public int effectStrength;

    public GameObject impactEffect;

    //public float enemyProximity;
    //public float rangedEnemyProximity;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDie);

        if (shieldDamage == 0)
        {
            //shieldDamage = damage;


        }
    }

    // Update is called once per frame
    void Update()
    {
        //enemy = GameObject.FindWithTag("Enemy").transform;
        //enemyProximity = Vector3.Distance(enemy.position, transform.position);

        //rangedEnemy = GameObject.FindWithTag("Enemy").transform;
        //rangedEnemyProximity = Vector3.Distance(rangedEnemy.position, transform.position);
        transform.Translate(Vector3.forward * Time.deltaTime * velocity);
        range = velocity * timeToDie;
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            //EnemyMove en = other.gameObject.GetComponent<EnemyMove>();
            //en.TakeDamage(damage);

            AIhealth ahp = other.gameObject.GetComponent<AIhealth>();
            ahp.TakeDamage(damage, shieldDamage, effectStrength);
            Destroy(gameObject);
        }

        else if (other.gameObject.CompareTag("Ranged Enemy"))
        {
            AIhealth ahp = other.gameObject.GetComponent<AIhealth>();
            ahp.TakeDamage(damage, shieldDamage, effectStrength);
            Destroy(gameObject);

        }

        else if (other.gameObject.CompareTag("Weapon"))
        {




        }

        else if (other.gameObject.CompareTag("Friendly"))
        {
            AIhealth ahp = other.gameObject.GetComponent<AIhealth>();
            ahp.TakeDamage(damage, shieldDamage, effectStrength);
            Destroy(gameObject);


        }

        else if (other.gameObject.CompareTag("Player"))
        {
            Move mv = other.gameObject.GetComponent<Move>();
            mv.TakeDamage(damage, shieldDamage);
            Destroy(gameObject);

        }

        else if (other.gameObject.CompareTag("Casing"))
        {




        }

        /*else if (other.gameObject.CompareTag("Player"))
        {


        }*/

        else
        {

            Destroy(gameObject);

        }
    }
}
