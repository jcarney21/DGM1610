using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;

    public float rateOfFire;
    public float firingFrequency;
    public float firingDuration;

    public float fireTimer;
    public float durationTimer;

    public int ammo;
    public int reloadTime;

    public int reloadTimer;

    public bool fireOrders;

    public float clearance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fireOrders)
        {
            fireTimer += Time.deltaTime;
            durationTimer += Time.deltaTime;


        }
        

        if(durationTimer > firingFrequency && fireTimer > rateOfFire && fireOrders)
        {
            Instantiate(projectile, transform.position + Vector3.forward * clearance, transform.rotation);
            fireTimer = 0;


        }

        if(durationTimer > firingDuration)
        {
            durationTimer = 0;


        }

    }
}
