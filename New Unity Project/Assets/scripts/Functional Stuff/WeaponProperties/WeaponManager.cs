using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public float weaponDmg;
    public int magazine;
    public int magazineMax;
    public int ammoCarrying;
    public int ammoMax;
    public int spawnAmmo;
    public int magazineValue;
    public float spreadMax;

    public float temperature;
    public float heatstep;
    public float overheatThreshold;

    public float rateOfSpread;
    public float spread;


    public float loudness;

    public float reloadCycle;
    public float reloadTime;

    public float fireCycle;
    public float rateOfFire;

    public float proximityToPlayer;

    public string weaponName;

    public bool autoFire;
    public bool fireSwitch;
    public bool isActiveWeapon;
    public bool isHoldingWeapon;
    public bool isReloading;
    public bool heldByEnemy;
    public bool energyWeapon;

    public static bool canPickupAmmo;
    public static bool currentlyActive;
    public GameObject bulletPrefab;
    public GameObject casingPrefab;

    public Transform activeSlot;
    public Transform player;
    public Transform reserveSlot;
    private Rigidbody weaponRB;

    public Text pressEToPickup;
    public Text magazinetext;
    public Text carryingtext;

    // Start is called before the first frame update
    void Start()
    {
        magazine = magazineMax;
        ammoCarrying = spawnAmmo;
        weaponRB = GetComponent<Rigidbody>();

        
    }

    // Update is called once per frame
    void Update()
    {
        

        currentlyActive = isActiveWeapon;
        canPickupAmmo = isActiveWeapon;

        
        if (energyWeapon && temperature > overheatThreshold)
        {
            isReloading = true;
            temperature = overheatThreshold - 1;


        }

        //Data for firing weapon
        if (isActiveWeapon && isHoldingWeapon)
        {
            if (magazine > 0 && fireCycle >= rateOfFire && !isReloading)
            {
                if (autoFire)
                {
                    if (Input.GetButton("Fire1"))
                    {
                        Instantiate(bulletPrefab, transform.position, transform.rotation * Quaternion.Euler(Random.Range(0 - spread, 0 + spread), Random.Range(0 - spread, 0 + spread), 0));
                        
                        magazine -= 1;
                        fireCycle = 0;
                        print("Ammo in Mag: " + magazine);
                        
                        if (spread < spreadMax)
                        {
                            spread += (rateOfSpread * Time.deltaTime);


                        }

                        if (energyWeapon)
                        {
                            temperature += heatstep;


                        }

                        //allows the enemy to hear the gunshot
                        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
                        foreach (GameObject enemy in enemies)
                        {
                            var enemyLocation = enemy.transform;
                            var enemyProximity = Vector3.Distance(enemyLocation.position, transform.position);
                            AIWeaponuser aiwu = enemy.GetComponent<AIWeaponuser>();
                            if (enemyProximity < loudness)
                            {
                                aiwu.HeardGunfire();


                            }

                        }

                        Instantiate(casingPrefab, transform.position, transform.rotation);

                    }
                    else
                    {
                        if (temperature > 0)
                        {
                            temperature -= (Time.deltaTime);


                        }
                        else
                        {
                            temperature = 0;


                        }

                        if (spread > 0)
                        {
                            spread -= Time.deltaTime;


                        }

                    }

                }

                else if (!autoFire)
                {
                    if (Input.GetButtonDown("Fire1"))
                    {
                        
                        Instantiate(bulletPrefab, transform.position, transform.rotation * Quaternion.Euler(Random.Range(0 - spread, 0 + spread), Random.Range(0 - spread, 0 + spread), 0));
                        
                        magazine -= 1;
                        fireCycle = 0;
                        print("Ammo in Mag: " + magazine);

                        if (energyWeapon)
                        {
                            temperature += heatstep;


                        }

                        //allows the enemy to hear the gunshot
                        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
                        foreach (GameObject enemy in enemies)
                        {
                            var enemyLocation = enemy.transform;
                            var enemyProximity = Vector3.Distance(enemyLocation.position, transform.position);
                            AIWeaponuser aiwu = enemy.GetComponent<AIWeaponuser>();
                            if (enemyProximity < loudness)
                            {
                                aiwu.HeardGunfire();


                            }

                        }
                        Instantiate(casingPrefab, transform.position, transform.rotation);
                    }
                    else
                    {
                        
                        if (temperature > 0)
                        {
                            temperature -= (Time.deltaTime);


                        }
                        else
                        {
                            temperature = 0;

                        }

                        if (spread > 0)
                        {
                            spread -= (rateOfSpread * Time.deltaTime);


                        }

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
            print("Reloading");

        }

        if (Input.GetKeyDown("r") && ammoCarrying > 0 && magazine < magazineMax)
        {
            isReloading = true;
            print("Reloading");

        }

        if (isReloading && isActiveWeapon)
        {
            reloadCycle += Time.deltaTime;
            temperature -= (Time.deltaTime * (overheatThreshold/reloadTime));

        }

        else if (isReloading && !isActiveWeapon)
        {
            reloadCycle = 0;
            isReloading = false;


        }

        if (reloadCycle >= reloadTime)
        {
            reloadCycle = 0;
            magazineValue = magazine;
            temperature = 0;
            spread = 0;
            if (ammoCarrying >= magazineMax && !energyWeapon)
            {
                magazine = magazineMax;

            }

            else if (ammoCarrying < magazineMax && !energyWeapon)
            {
                magazine = ammoCarrying;


            }

            ammoCarrying = ammoCarrying - (magazineMax - magazineValue);
            isReloading = false;
            print("Ammunition: " + ammoCarrying);

        }

        if (ammoCarrying < 0)
        {
            ammoCarrying = 0;


        }

        if (ammoCarrying > ammoMax)
        {
            ammoCarrying = ammoMax;


        }

        // Data to determine if you are holding a weapon
        activeSlot = GameObject.FindWithTag("Active Slot").transform;
        player = GameObject.FindWithTag("Player").transform;
        reserveSlot = GameObject.FindWithTag("Reserve Slot").transform;
        proximityToPlayer = Vector3.Distance(player.position, transform.position);

        if (isActiveWeapon)
        {
            magazinetext.text = magazine.ToString();
            carryingtext.text = ammoCarrying.ToString();

            if (energyWeapon)
            {
                carryingtext.text = temperature.ToString();


            }

            //gameObject.transform.SetParent(activeParent, false);
            if (magazine > magazineMax)
            {
                magazineValue = magazine;
                magazine = magazineMax;
                ammoCarrying += (magazineValue - magazineMax);



            }

        }

        if (!isActiveWeapon)
        {
            //gameObject.transform.SetParent(reserveParent, false);



        }

        if (isHoldingWeapon == true)
        {
            if (isActiveWeapon == false)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    isActiveWeapon = true;
                    temperature = 0;
                    //gameObject.transform.SetParent(activeParent, false);
                    transform.position = activeSlot.transform.position;
                    transform.rotation = activeSlot.transform.rotation;
                }


            }

            else if (isActiveWeapon == true)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    isActiveWeapon = false;
                    //gameObject.transform.SetParent(reserveParent, false);
                    transform.position = reserveSlot.transform.position;
                    transform.rotation = reserveSlot.transform.rotation;
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    isHoldingWeapon = false;
                    isActiveWeapon = false;
                    gameObject.transform.parent = null;
                    weaponRB.constraints = RigidbodyConstraints.None;

                }


            }

        }

        else if (isHoldingWeapon == false)
        {
            if (proximityToPlayer < 3 && !heldByEnemy)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    isHoldingWeapon = true;
                    isActiveWeapon = true;
                    gameObject.transform.SetParent(player);
                    transform.position = activeSlot.transform.position;
                    transform.rotation = activeSlot.transform.rotation;
                    weaponRB.constraints = RigidbodyConstraints.FreezeAll;
                }

                //print("Press E to pick up " + gameObject.name);
                pressEToPickup.text = "Press E to pick up " + weaponName;
                
            }

            else
            {
                pressEToPickup.text = "   ";




            }
            
        }

        if (fireSwitch && Input.GetKeyDown(KeyCode.Alpha2))
        {
            autoFire = !autoFire;



        }
    }

    void OnTriggerStay(Collider other)
    {
        
    }

    public void AmmoPickup(int ammoToAdd)
    {
       if (isActiveWeapon || isHoldingWeapon)
       {
            ammoCarrying = ammoCarrying + ammoToAdd;
            print("Ammo Total: " + ammoCarrying);




        }
    }

    public void Fire()
    {
        if (fireCycle >= rateOfFire && heldByEnemy)
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            fireCycle = 0;


        }


    }
}
