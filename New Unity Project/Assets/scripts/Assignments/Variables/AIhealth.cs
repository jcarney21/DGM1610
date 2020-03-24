using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIhealth : MonoBehaviour
{
    public float maxHealth;
    public float maxShields;
    public float spawnShields;
    public float spawnHealth;
    public float aiHealth;
    public float aiShields;
    public int pointsToAdd;
    public int armor;
    public int shieldArmor;

    public bool regeneratingHealth;
    public bool regeneratingShields;
    public float healthRegen;
    public float shieldRegen;
    public float hpDelay;
    public float shieldDelay;

    public float hpclock;
    public float shieldClock;

    public bool justGotHit;

    public GameObject shieldEffect;
    public GameObject healthEffect;
    //public GameObject deathEffect;
    //public int deathAmount;
    // Start is called before the first frame update
    void Start()
    {
        aiHealth = spawnHealth;
        aiShields = spawnShields;
        
    }

    // Update is called once per frame
    void Update()
    {
        justGotHit = false;
        if (aiHealth <= 0)
        {
            /*for (int i = 0; i < deathAmount; i++)
            {
                Instantiate(deathEffect, transform.position, transform.rotation * Quaternion.Euler(Random.Range(-10, 90), Random.Range(-30, 30), 0));



            }*/

            Destroy(gameObject);
            ScoreManager.AddPoints(pointsToAdd);
        }

        if (aiShields < 0)
        {
            aiShields = 0;


        }

        if (regeneratingShields && aiShields < maxShields)
        {
            if (shieldClock >= shieldDelay)
            {
                aiShields += (Time.deltaTime * shieldRegen);



            }


        }

        if (regeneratingHealth && aiHealth < maxHealth)
        {
            if (hpclock >= hpDelay)
            {
                aiHealth += (Time.deltaTime * healthRegen);



            }


        }

        if (hpclock < hpDelay && regeneratingHealth)
        {
            hpclock += Time.deltaTime;



        }

        if (shieldClock < shieldDelay && regeneratingShields)
        {
            shieldClock += Time.deltaTime;



        }
    }

    public void TakeDamage(int damage, int shieldDamage, int effectStrength)
    {
        justGotHit = true;
        if (aiShields <= 0)
        {
            aiHealth -= (damage - armor);
            hpclock = 0;
            for (int i = 0; i < effectStrength; i++)
            {
                Instantiate(healthEffect, transform.position, transform.rotation * Quaternion.Euler(Random.Range(-5, 5), Random.Range (-30, 30), 0));
                


            }

        }

        else if (aiShields > 0)
        {
            aiShields -= (shieldDamage - shieldArmor);
            shieldClock = 0;

            for (int i = 0; i < effectStrength; i++)
            {
                Instantiate(shieldEffect, transform.position, transform.rotation * Quaternion.Euler(Random.Range(-5, 5), Random.Range (-180, 180), 0));
                


            }

        }

    }
}
