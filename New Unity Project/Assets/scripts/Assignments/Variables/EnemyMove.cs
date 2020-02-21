using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform target;
    public int damage;
    public float moveSpeed;
    public float enemyHealth;
    public int pointsToAdd;

    public bool isRanged;
    public float playerProximity;
    public float enemyRange;
    public float enemyCooldown;
    public float enemyRof;
    public GameObject fireballPrefab;
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
        enemyCooldown += Time.deltaTime;

        playerProximity = Vector3.Distance(target.position, transform.position);

        if (enemyHealth < 1)
        {
            Destroy(gameObject);
            ScoreManager.AddPoints(pointsToAdd);

        }

        if (playerProximity < enemyRange)
        {
            if (isRanged == true)
            {
                transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
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
            enemyHealth = enemyHealth - 25;


        }

        else if (other.gameObject.CompareTag("Player"))
        {
            Move.TakeDamage(damage);


        }

    }
}
