using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWeaponuser : MonoBehaviour
{
    public float weaponProximity;
    public Transform wepLocation;
    public Transform playerLocation;
    public Transform patrolLocation;
    public float turnSpeed;
    public float walkSpeed;
    public float patrolDistance;

    public int status;
    private int guarding = 1;
    private int patrolling = 2;
    private int movingUp = 8;
    private int attacking = 3;
    private int cautiousAttacking = 4;
    private int defending = 5;
    private int retreating = 6;
    private int fleeing = 7;

    // for deciding if it knows about the player
    public bool awareOfPlayer;
    public bool canSeePlayer;
    public bool targetingPlayer;

    public bool firing;
    public bool turning;
    public float firingFrequency;
    public float firingCooldown;
    public float firingDuration;

    public int rotateDistance;
    public bool walking;
    // Start is called before the first frame update
    void Start()
    {
        status = attacking;
        if (status == guarding)
        {
            InvokeRepeating("GuardingBehavior", 5.0f, 3f);
            walking = false;

        }

        if (status == patrolling)
        {
            walking = true;
            InvokeRepeating("PatrollingBehavior", 0.1f, 3f);


        }
    }

    // Update is called once per frame

    void Update()
    {
        if (!awareOfPlayer)
        {
            var patrolPoint = GameObject.FindWithTag("PatrolPoint");
            patrolLocation = patrolPoint.transform;
            var proximity = Vector3.Distance(patrolLocation.position, transform.position);
            if (status == guarding && turning)
            {
                
                
                transform.Rotate(Vector3.up * turnSpeed * rotateDistance/5);



            }

            if (status == patrolling && proximity < patrolDistance)
            {
                if (turning)
                {

                    transform.Rotate(Vector3.up * turnSpeed * rotateDistance / 5);


                }

                if (walking)
                {
                    transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);



                }

            }
            else if (status == patrolling && proximity > patrolDistance)
            {
                transform.LookAt(patrolLocation, Vector3.up * turnSpeed);
                transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);



            }




        }
        else if (awareOfPlayer)
        {
            if (status == attacking)
            {
                targetingPlayer = true;
                firing = true;


            }

            else if (status == cautiousAttacking)
            {



            }
            else if (status == defending)
            {





            }

        }

        if (targetingPlayer)
        {
            transform.LookAt(playerLocation);
            playerLocation = GameObject.FindWithTag("Player").transform;


        }
        var weapons = GameObject.FindGameObjectsWithTag("Weapon");
        foreach (GameObject weapon in weapons)
        {
            wepLocation = weapon.transform;
            weaponProximity = Vector3.Distance(wepLocation.position, transform.position);
            WeaponManager wm = weapon.GetComponent<WeaponManager>();
            //bool heldByEnemy = wm;
            if (weaponProximity < 2 && firingCooldown >= firingFrequency)
            {
                wm.Fire();

            }

            else if (firingCooldown >= firingFrequency + firingDuration)
            {
                firingCooldown = 0;



            }




        }


        if (firing)
        {
            firingCooldown += Time.deltaTime;



        }
    }

    void GuardingBehavior()
    {

        print("Turning");
        //float timer = 0;
        /*while(timer < 4.0f)
        {
            turning = true;
            timer += Time.deltaTime;

        }*/

        turning = !turning;
        rotateDistance = Random.Range(-5, 5);
    }

    void PatrollingBehavior()
    {
        print("Patrolling");
        turning = !turning;
        walking = !walking;
        rotateDistance = Random.Range(-5, 5);


    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {





        }

        else if (other.gameObject.CompareTag("Ground"))
        {




        }

        else
        {
            //walking = false;
            //turning = true;



        }


    }
}
