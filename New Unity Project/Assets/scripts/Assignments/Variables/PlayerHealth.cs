using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public const int maxhealth = 100;

    public int currentHealth = maxhealth;

    public Text hp;

    public Text maxhp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hp.text = currentHealth.ToString();
        maxhp.text = maxhealth.ToString();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            print("You're dead, game over");


        }

    }
}
