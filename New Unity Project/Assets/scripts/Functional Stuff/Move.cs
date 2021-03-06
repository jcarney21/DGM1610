﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float verticalTurnSpeed;
    public float verticalInput;
    public float horizontalInput;
    public float updownInput;
    public float strafeInput;

    public int ammoMag;
    public static int ammoTotal;

    public bool isGrounded;
    public float jumpHeight;
    private Rigidbody rb;

    public static int health;
    public static float shields;
    public int maxShields;
    public int maxHealth;
    public static float shieldCooldown;
    public float rechargeDelay;
    public int rechargeRate;
    public int shieldRecharges;

    public float cooldown;
    public float rof;

    private float energyLevel;
    public Text energy;
    //public GameObject fragGrenade;
    //public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        ammoMag = 15;
        ammoTotal = 15;
        health = maxHealth;
        shields = maxShields;

        rb = GetComponent<Rigidbody>();
     
    }

    // Update is called once per frame
    void Update()
    {

        //Inputs
        verticalInput = Input.GetAxis("Vertical");
        strafeInput = Input.GetAxis("Horizontal");
        horizontalInput = Input.GetAxis("Mouse X");
        updownInput = Input.GetAxis("Mouse Y");

        // transformations
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);//Equal 2 (0, 0, .1f)
        transform.Translate(Vector3.right * speed * Time.deltaTime * strafeInput);
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * horizontalInput);
        //transform.Rotate(Vector3.left * verticalTurnSpeed * Time.deltaTime * updownInput);

        //Grenade

        /*if (Input.GetKeyDown(KeyCode.G))
        {
            Instantiate(fragGrenade, transform.position, transform.rotation);


        }*/

        //Jump

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpHeight * 1000 * Time.deltaTime * 100);



        }

        // Defunct Jump Code
        /*if (Input.GetKey(KeyCode.Space))
        {
            if (jumpHeight > 0)
            {
                jumpHeight = jumpHeight - Time.deltaTime;

            }
            transform.Translate(Vector3.up * jumpHeight);


        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpHeight = .3f;

        }*/

        /*if (isGrounded && Input.GetButtonDown("Jump"))
        {
            


        }*/

        // x, y, z

        //Firing and Ammo

        /*if (Input.GetButtonDown("Fire1"))
        {
            if (ammoMag >= 1)
            {
                
                //Instantiate(projectilePrefab, transform.position, transform.rotation); //projectilePrefab.transform.rotation
                 ammoMag = ammoMag - 1;
                print("ammunition: " + ammoMag);


            }

            else
            {
                print("No Ammo");

            }
            
        }

        if (ammoMag < 1)
        {
            if (ammoTotal >= 1)
            {
                ammoMag = 15;
                ammoTotal = ammoTotal - 15;
                print("ammunition: " + ammoMag);
                print("Total Ammo: " + ammoTotal);


            }
         

        }*/

        //Automatic Rifle

        /*if (cooldown < 1)
        {
            cooldown += Time.deltaTime;


        }
        if (Input.GetButton("Fire2"))
        {
            if (ammoMag >= 1)
            {
                if (cooldown > rof)
                {
                    //Instantiate(projectilePrefab, transform.position, transform.rotation); //projectilePrefab.transform.rotation
                    ammoMag = ammoMag - 1;
                    print("ammunition: " + ammoMag);
                    cooldown = 0;


                }


            }

            else
            {
                print("No Ammo");

            }


        }*/
        //GetKeyDown is a single input, Get key (or getdown, because I don't remember) continues each time it fires
        // Shielding
        if (shields < maxShields && Input.GetKeyDown(KeyCode.LeftShift) && shieldRecharges > 0)
        {
            shields = maxShields;
            shieldRecharges--;


        }

        energyLevel = shieldRecharges * 25;
        energy.text = "Energy " + energyLevel;
        // unused system for shield recharge
        /*if (shields < maxShields && shieldCooldown > rechargeDelay)
        {
            shields += Time.deltaTime;



        }

        if (shields == maxShields)
        {
            shieldCooldown = 0;


        }
        else if (shields < maxShields)
        {
            shieldCooldown += Time.deltaTime;




        }*/

        if (health <= 0)
        {

            speed = 0;
            turnSpeed = 0;
            print("Game Over");
            shieldRecharges = 0;
            jumpHeight = 0;

        }

        if (health >= maxHealth)
        {
            health = maxHealth;

        }

        if (shields < 0)
        {
            shields = 0;


        }
    }

    /*public static void AddAmmo(int ammoToAdd)
    {
        ammoTotal = ammoTotal + ammoToAdd;
        print("Ammo Total: " + ammoTotal);


    }*/

    public static void AddHealth(int healthAmt)
    {
        health = health + healthAmt;
        print("Current HP " + health);

    }

    public void TakeDamage(int damage, int shieldDamage)
    {
        shieldCooldown = 0;
        if (shields > 0)
        {
            shields -= shieldDamage;


        }

        else
        {
            health = health - damage;


        }
        print("Current HP " + health);

    }

    public void AddRecharge (int rechargeToAdd)
    {
        shieldRecharges += rechargeToAdd;

    }

    
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Obstacle"))
        {
            isGrounded = true;


        }

        else
        {
            


        }

    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {




        }

        else if (other.gameObject.CompareTag("Ranged Enemy"))
        {




        }

        else
        {
            isGrounded = false;


        }

    }
    // Detect collision with another object
    /*void OnCollisionEnter(Collision other){
        

        if (other.gameObject.CompareTag("Ground"))//Primary
        {
            Debug.Log("Colliding with Floor");
        }
        else if(other.gameObject.CompareTag("Obstacle"))//Secondary
        {
            Debug.Log("Colliding with an Obstacle");
        }
        else//Tertiary or default
        {
            Debug.Log("...");
        
        }
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("Triggered");
    }
    */
}
