using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public static int currentHealth;
    public int maxHealth;
    public Transform spawnPoint;
    public static int pointsToAdd;
    public int pointsValue;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //spawnPoint = GameObject.Find("SpawnPoint");
        pointsToAdd = pointsValue;
    }

    public static void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            print("Enemy is dead");
            // Add points to score for killing enemy
            ScoreManager.AddPoints(pointsToAdd);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth < 1)
        {
            //Destroy(gameObject);


        }
    }
}
