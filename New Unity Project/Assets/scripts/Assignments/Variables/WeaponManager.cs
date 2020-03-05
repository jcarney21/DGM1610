using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public float weaponDmg;
    public int magazine;
    public int magazineMax;
    public int ammoCarrying;
    public int ammoMax;
    public int spawnAmmo;
    public int magazineValue;

    public float reloadCycle;
    public float reloadTime;

    public float fireCycle;
    public float rateOfFire;

    public float proximityToPlayer;
    

    public bool autoFire;
    public bool isActiveWeapon;
    public bool isHoldingWeapon;
    public bool isReloading;
    public GameObject bulletPrefab;

    public Transform activeParent;
    public Transform reserveParent;

    // Start is called before the first frame update
    void Start()
    {
        magazine = magazineMax;
        ammoCarrying = spawnAmmo;

    }

    // Update is called once per frame
    void Update()
    {

        //Data for firing weapon
        if (isActiveWeapon && isHoldingWeapon)
        {
            if (magazine > 0 && fireCycle >= rateOfFire && !isReloading)
            {
                if (autoFire)
                {
                    if (Input.GetButton("Fire1"))
                    {
                        Instantiate(bulletPrefab, transform.position, transform.rotation);
                        magazine -= 1;
                        fireCycle = 0;
                        

                    }


                }

                else if (!autoFire)
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        
                        Instantiate(bulletPrefab, transform.position, transform.rotation);
                        magazine -= 1;
                        fireCycle = 0;
                    }



                }

            }

            else if (magazine == 0)
            {
                print("Reload");


            }

            else if (magazine == 0 && ammoCarrying == 0)
            {
                print("No Ammo");


            }

            else if (isReloading)
            {
                print("Reloading");



            }


        }

        if (fireCycle < rateOfFire)
        {
            fireCycle += Time.deltaTime;



        }

        if (fireCycle > rateOfFire)
        {
            fireCycle = rateOfFire;



        }

        //Ammunition and reloading
        if (magazine == 0 && ammoCarrying > 0)
        {
            isReloading = true;


        }

        if (Input.GetKeyDown("r") && ammoCarrying > 0 && magazine < magazineMax)
        {
            isReloading = true;


        }

        if (isReloading)
        {
            reloadCycle += Time.deltaTime;


        }

        if (reloadCycle >= reloadTime)
        {
            reloadCycle = 0;
            magazineValue = magazine;
            if (ammoCarrying >= magazineMax)
            {
                magazine = magazineMax;

            }

            else if (ammoCarrying < magazineMax)
            {
                magazine = ammoCarrying;


            }
            ammoCarrying = ammoCarrying - (magazineMax - magazineValue);
            isReloading = false;


        }

        if (ammoCarrying < 0)
        {
            ammoCarrying = 0;


        }

        // Data to determine if you are holding a weapon
        activeParent = GameObject.FindWithTag("Active Slot").transform;
        reserveParent = GameObject.FindWithTag("Reserve Slot").transform;

        if (isActiveWeapon)
        {
            gameObject.transform.SetParent(activeParent, false);


        }

        if (!isActiveWeapon)
        {
            gameObject.transform.SetParent(reserveParent, false);



        }

        if (isHoldingWeapon == true)
        {
            if (isActiveWeapon == false)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    isActiveWeapon = true;
                    gameObject.transform.SetParent(activeParent, false);

                }


            }

            else if (isActiveWeapon == true)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    isActiveWeapon = false;
                    gameObject.transform.SetParent(reserveParent, false);

                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    isHoldingWeapon = false;
                    isActiveWeapon = false;



                }


            }

        }

        else if (isHoldingWeapon == false)
        {
            if (proximityToPlayer < 2)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    isHoldingWeapon = true;
                    isActiveWeapon = true;


                }



            }


        }
    }

    void OnTriggerStay(Collider other)
    {
        
    }
}
