﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //public GameObject player;
    public Transform target; //used for transform.translate
    public int damage;
    public int shieldDamage;
    public float moveSpeed;
    public int enemyHealth;
    public int pointsToAdd;
    public int damageTaken;
    public int spawnHealth;
    public float lifetime;

    public bool isRanged;
    public float playerProximity;
    public float sightRange;
    public float enemyRange;
    public float enemyCooldown;
    public float enemyRof;
    public GameObject fireballPrefab;
    //private Rigidbody enemyRb; //Velocity and Add Force examples
    // Another Option is to set target as GameObject

    // Start is called before the first frame update
    void Start()
    {
        //enemyRb = GetComponent<Rigidbody>();
        //player = GameObject.Find("Player");
        enemyHealth = spawnHealth;
        shieldDamage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime += Time.deltaTime;

        if (playerProximity < sightRange)
        {
            transform.LookAt(target);
            target = GameObject.FindWithTag("Player").transform;


        }

        //transforming.translate stuff
        
        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        target = GameObject.FindWithTag("Player").transform;

        enemyCooldown += Time.deltaTime;
        
        //measures the object's distance from player
        playerProximity = Vector3.Distance(target.position, transform.position);
        if (playerProximity > enemyRange && playerProximity < sightRange)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);



        }

        if (enemyHealth < 1)
        {
            Destroy(gameObject);
            ScoreManager.AddPoints(pointsToAdd);

        }

        if (playerProximity < enemyRange)
        {
            if (isRanged == true)
            {
                //transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
                if (enemyCooldown >= enemyRof)
                {
                    Instantiate(fireballPrefab, transform.position, transform.rotation);
                    enemyCooldown = 0;


                }


            }

        }

        if (playerProximity > 100)
        {
            Destroy(gameObject);

        }
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Bullet"))
        {
            //enemyHealth -= 25;


        }

        else if (other.gameObject.CompareTag("Player"))
        {
            Move mv = other.gameObject.GetComponent<Move>();
            mv.TakeDamage(damage, shieldDamage);


        }

    }

    public void TakeDamage (int damage)
    {
        enemyHealth -= damage;

    }

    /*public static void TakeDamage(int damageToTake)
    {
        enemyHealth = enemyHealth - damageToTake;

    }*/

    /*void FixedUpdate()
    {
        enemyRb.AddForce((player.transform.position - transform.position).normalized * moveSpeed);


    } */
}
