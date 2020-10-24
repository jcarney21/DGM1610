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
    public int maxAmmo;
    public int reloadTime;
    public float accuracy;

    public float reloadTimer;

    public bool fireOrders;

    //public float clearance;

    // Start is called before the first frame update
    void Start()
    {
        //if (clearance <= 0)
        //{
            //clearance =  .1f;

        //}
    }

    // Update is called once per frame
    void Update()
    {

        //Determines when the unit's fire cycle starts
        if (fireOrders)
        {
            fireTimer += Time.deltaTime;
            durationTimer += Time.deltaTime;


        }
        
        
        if(durationTimer > firingFrequency && fireTimer > rateOfFire && fireOrders && ammo > 0)
        {
            Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(Random.Range(0 - accuracy, 0 + accuracy), Random.Range(0 - accuracy, 0 + accuracy), 0));
            fireTimer = 0;
            ammo -= 1;

        }

        //Determines how long the unit fires
        if(durationTimer > firingDuration)
        {
            durationTimer = 0;


        }

        //Reloading
        if (ammo <= 0)
        {
            reloadTimer += Time.deltaTime;

            if (reloadTimer >= reloadTime)
            {
                ammo = maxAmmo;
                reloadTimer = 0;


            }


        }



    }

    public void OrdersToFire (bool fire)
    {
        fireOrders = fire;



    }
}
