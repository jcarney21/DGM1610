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
    public float maxRange;
    public float distanceFromPlayer;
    public float firingFrequency;
    public float firingDuration;
    public int agressiveness;
    public int rotateDistance;
    public bool walking;
    public bool protectingALocation;
    public float sightDistance;
    public float fieldOfViewRange;
    public float forgetfulness;

    public int status;
    private int previousCondition;
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
    public float firingCooldown;

    public float awarenessCooldown;
    // Start is called before the first frame update
    void Start()
    {
        status = guarding;
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
        previousCondition = status;
    }

    // Update is called once per frame

    void Update()
    {
        // for raycasting. I found it in a Unity tutorial or something
        var player = GameObject.FindWithTag("Player");
        RaycastHit hit;
        //Ray lineOfSight = new Ray(transform.position, Vector3.forward);
        Vector3 rayDirection = player.transform.position - transform.position;

        /*if (Physics.Raycast(lineOfSight, out hit, sightDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                awareOfPlayer = true;
                canSeePlayer = true;
                //sightCooldown = 2;
                

            }

            else
            {
                

            }


        }*/

        // all of this helps the Ai determine if it can see the player
        if ((Vector3.Angle(rayDirection, transform.forward)) < fieldOfViewRange)
        {
            if (Physics.Raycast(transform.position, rayDirection, out hit, sightDistance))
            {
                if (hit.transform.CompareTag("Player"))
                {

                    canSeePlayer = true;
                    awareOfPlayer = true;
                    awarenessCooldown = forgetfulness;
                }

                else
                {
                    canSeePlayer = false;
                }



            }




        }

        if (!canSeePlayer && awareOfPlayer)
        {
            awarenessCooldown -= Time.deltaTime;


        }

        if (awarenessCooldown <= 0 && awareOfPlayer)
        {
            awareOfPlayer = false;
            status = previousCondition;


        }

        if (!awareOfPlayer)// contains the behaviors for guarding and patrolling
        {
            var patrolPoint = GameObject.FindWithTag("PatrolPoint");
            patrolLocation = patrolPoint.transform;
            var proximity = Vector3.Distance(patrolLocation.position, transform.position);
            if (status == guarding && turning)
            {

                previousCondition = guarding;
                transform.Rotate(Vector3.up * turnSpeed * rotateDistance/5);



            }

            if (status == patrolling && proximity < patrolDistance)
            {
                if (turning)
                {
                    previousCondition = patrolling;
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
        else if (awareOfPlayer) // once the ai sees a player, this decides whether it attacks or defends
        {
            if (protectingALocation)
            {
                status = defending;



            }

            else if (!protectingALocation)
            {
                var playerHealth = Move.health;
                var playerShields = Move.shields;
                if (agressiveness > 10 || playerShields < 10)
                {
                    status = attacking;


                }

                else if (agressiveness < 10 && playerShields > 10)
                {
                    status = cautiousAttacking;




                }




            }

            if (status == attacking) // this is for when the ai is attacking agressively
            {
                targetingPlayer = true;
                firing = true;


            }

            else if (status == cautiousAttacking) // this is for when the AI is in standard attack mode
            {



            }
            else if (status == defending) // this is for when the AI is in defensive mode
            {
                if (!canSeePlayer)
                {
                    firing = false;
                    targetingPlayer = false;
                    var patrolPoint = GameObject.FindWithTag("PatrolPoint");
                    patrolLocation = patrolPoint.transform;
                    var proximity = Vector3.Distance(patrolLocation.position, transform.position);



                    if (proximity < patrolDistance)
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
                    else if (proximity > (patrolDistance + 5))
                    {
                        transform.LookAt(patrolLocation, Vector3.up * turnSpeed);
                        transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);



                    }




                }
                else if (canSeePlayer)
                {
                    playerLocation = GameObject.FindWithTag("Player").transform;
                    distanceFromPlayer = Vector3.Distance(playerLocation.position, transform.position);

                    var patrolPoint = GameObject.FindWithTag("PatrolPoint");
                    patrolLocation = patrolPoint.transform;
                    var proximity = Vector3.Distance(patrolLocation.position, transform.position);
                    if (distanceFromPlayer < maxRange)
                    {
                        targetingPlayer = true;
                        firing = true;



                    }
                    else if (distanceFromPlayer > maxRange && proximity <= patrolDistance)
                    {
                        targetingPlayer = true;
                        transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
                        firing = false;

                    }
                    else if (distanceFromPlayer > maxRange && proximity > patrolDistance)
                    {
                        targetingPlayer = true;
                        firing = false;

                    }



                }




            }

        }

        if (targetingPlayer)
        {
            transform.LookAt(playerLocation);
            playerLocation = GameObject.FindWithTag("Player").transform;


        }

        // this stuff decides what weapon the ai is holding
        var weapons = GameObject.FindGameObjectsWithTag("Weapon");
        foreach (GameObject weapon in weapons)
        {
            wepLocation = weapon.transform;
            weaponProximity = Vector3.Distance(wepLocation.position, transform.position);
            WeaponManager wm = weapon.GetComponent<WeaponManager>();
            //bool heldByEnemy = wm;
            if (weaponProximity < 2 && firingCooldown >= firingFrequency && firing)
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
