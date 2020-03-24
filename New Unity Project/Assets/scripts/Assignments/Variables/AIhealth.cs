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

    // Start is called before the first frame update
    void Start()
    {
        aiHealth = spawnHealth;
        aiShields = spawnShields;
    }

    // Update is called once per frame
    void Update()
    {
        if (aiHealth <= 0)
        {
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

    public void TakeDamage(int damage, int shieldDamage)
    {
        if (aiShields <= 0)
        {
            aiHealth -= (damage - armor);
            hpclock = 0;
        }

        else if (aiShields > 0)
        {
            aiShields -= (shieldDamage - shieldArmor);
            shieldClock = 0;


        }

    }
}
