using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWeaponuser : MonoBehaviour
{
    // this stuff decides what weapon it's holding
    public float weaponProximity;
    public Transform wepLocation;
    public Transform playerLocation;
    public Transform patrolLocation;

    // basic unit data (this should eventually be the only public stuff, I think.)
        //movement speed
    public float turnSpeed;
    public float walkSpeed;
    public bool flyingUnit;

        //firing behavior data
    public float firingFrequency;
    public float firingDuration;
    public float maxRange;
    public float meleeRange;
        //personality
    public float forgetfulness;
    public int agressiveness;
        //Orders
    public bool protectingALocation;
    public float patrolDistance;
    public int spawnStatus;
    //public int radioChannel;

    //Sight Data
    public float sightDistance;
    public float fieldOfViewRange;
        //health and shielding Data
    public float maxHealth;
    public float unitHealth;
    public float maxShields;
    public float unitShields;
    

    //directional and distance data
    public float strafingDirection;
    public int rotateDistance;
    public float distanceFromPlayer;
    public bool isGrounded;

    // status data
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

    // what is it acting
    public bool isRetreating;

    public Vector3 playersLastLocation;

    public bool strafing;
    public bool firing;
    public bool turning;
    public bool walking;
    public bool hasAlreadyRetreated;
    //public bool raisingAlarm;

    //cooldowns
    public float firingCooldown;
    public float timeRetreating;

    public float awarenessCooldown;
    // Start is called before the first frame update
    void Start()
    {
        
        if (spawnStatus == 0)
        {
            spawnStatus = 1;


        }

        status = spawnStatus;
        
        
        InvokeRepeating("GuardingBehavior", 5.0f, 3f);            
        

        
        
        InvokeRepeating("PatrollingBehavior", 0.1f, 3f);


        
        previousCondition = status;
        InvokeRepeating("StrafingBehavior", 4f, 4f);
        strafing = true;
        walking = false;
        turning = true;
        hasAlreadyRetreated = false;

    }

    // Update is called once per frame

    void Update()
    {
        //Connects to AI health
        AIhealth aiHealth = gameObject.GetComponent<AIhealth>();

        maxHealth = aiHealth.maxHealth;
        unitHealth = aiHealth.aiHealth;
        maxShields = aiHealth.maxShields;
        unitShields = aiHealth.aiShields;
        var justGotHit = aiHealth.justGotHit;

        if (flyingUnit)
        {

            isGrounded = true;

        }

        if (justGotHit)
        {
            awareOfPlayer = true;
            awarenessCooldown = forgetfulness;
            

        }
        // for raycasting. I found it in a Unity tutorial or something
        var player = GameObject.FindWithTag("Player");
        RaycastHit hit;
        //Ray lineOfSight = new Ray(transform.position, Vector3.forward);
        Vector3 rayDirection = player.transform.position - transform.position;


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
                    playersLastLocation = player.transform.position;
                }

                else
                {
                    canSeePlayer = false;
                    
                }



            }




        }

        /*if (awarenessCooldown < forgetfulness - 4 && awarenessCooldown > 0)
        {
            raisingAlarm = true;



        }*/

        // this decides when the AI forgets the player and moves to its previous status
        if (!canSeePlayer && awareOfPlayer)
        {
            awarenessCooldown -= Time.deltaTime;


        }

        if (awarenessCooldown <= 0 && awareOfPlayer)
        {
            awareOfPlayer = false;
            status = previousCondition;
            //raisingAlarm = false;

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

                if (walking && isGrounded)
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
                if (agressiveness >= 8 || playerShields < 10 && !isRetreating)
                {
                    status = attacking;


                }
                else if (agressiveness < 8 && playerShields > 10 && !isRetreating)
                {
                    status = cautiousAttacking;

                }
                else if (((unitHealth/maxHealth) * 10) < agressiveness && !hasAlreadyRetreated)
                {
                    if (agressiveness > 5)
                    {
                        status = retreating;
                        timeRetreating = (30 - agressiveness);
                        hasAlreadyRetreated = true;
                        isRetreating = true;

                    }
                    else if (agressiveness <= 4)
                    {
                        status = fleeing;
                        timeRetreating = (30 - agressiveness);
                        hasAlreadyRetreated = true;
                        isRetreating = true;

                    }


                }


            }

            if (status == attacking) // this is for when the ai is attacking agressively
            {
                if (canSeePlayer)
                {
                    targetingPlayer = true;
                    playerLocation = GameObject.FindWithTag("Player").transform;
                    distanceFromPlayer = Vector3.Distance(playerLocation.position, transform.position);
                    

                    if (distanceFromPlayer < maxRange)
                    {
                        firing = true;
                        if (walking && isGrounded)
                        {
                            transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);



                        }

                        else if (strafing && isGrounded)
                        {

                            transform.Translate(Vector3.left * walkSpeed * Time.deltaTime * strafingDirection/2);




                        }



                    }

                    else if (distanceFromPlayer > maxRange && isGrounded)
                    {
                        firing = false;
                        transform.Translate(Vector3.forward * walkSpeed * 1.5f * Time.deltaTime);




                    }

                    else if (distanceFromPlayer < meleeRange)
                    {




                    }

                }
                else if (!canSeePlayer)
                {
                    targetingPlayer = false;
                    firing = false;
                    distanceFromPlayer = Vector3.Distance(playersLastLocation, transform.position);
                    

                    if (distanceFromPlayer > 1)
                    {
                        transform.LookAt(playersLastLocation);
                        transform.Translate(Vector3.forward * walkSpeed * 1.5f * Time.deltaTime);


                    }

                    else if (distanceFromPlayer <= 1)
                    {
                        if (turning)
                        {
                            transform.Rotate(Vector3.up * turnSpeed * rotateDistance);



                        }



                    }




                }
            }

            else if (status == cautiousAttacking) // this is for when the AI is in standard attack mode
            {
                targetingPlayer = true;
                playerLocation = GameObject.FindWithTag("Player").transform;
                distanceFromPlayer = Vector3.Distance(playerLocation.position, transform.position);


                if (distanceFromPlayer < maxRange && canSeePlayer)
                {
                    firing = true;
                    if (walking)
                    {
                        



                    }

                    else if (strafing && isGrounded)
                    {

                        transform.Translate(Vector3.left * walkSpeed * Time.deltaTime * strafingDirection / 2);




                    }



                }

                else if (distanceFromPlayer > maxRange && isGrounded)
                {
                    firing = false;
                    transform.Translate(Vector3.forward * walkSpeed * 1.5f * Time.deltaTime);




                }

                else if (distanceFromPlayer < meleeRange)
                {




                }


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

                        if (walking && isGrounded)
                        {
                            transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);



                        }

                    }
                    else if (proximity > (patrolDistance + 5) && isGrounded)
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
                    else if (distanceFromPlayer > maxRange && proximity <= patrolDistance && isGrounded)
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

        // the info for what to do while retreating
        if (status == retreating) 
        {
            timeRetreating -= Time.deltaTime;
            playerLocation = GameObject.FindWithTag("Player").transform;
            distanceFromPlayer = Vector3.Distance(playerLocation.position, transform.position);
            if (distanceFromPlayer < maxRange && isGrounded)
            {
                targetingPlayer = true;
                firing = true;
                transform.Translate(Vector3.back * walkSpeed * Time.deltaTime);



            }
            else if (distanceFromPlayer >= maxRange && isGrounded)
            {
                targetingPlayer = false;
                firing = false;
                transform.Translate(Vector3.back * walkSpeed * Time.deltaTime);
                transform.Translate(Vector3.left * walkSpeed * Time.deltaTime * strafingDirection);

            }
            else if (distanceFromPlayer >= (maxRange + 15))
            {
                if (turning)
                {
                    transform.Rotate(Vector3.up * turnSpeed * rotateDistance / 5);



                }



            }

            if (timeRetreating <= 0)
            {
                status = previousCondition;
                isRetreating = false;



            }

        }
        else if (status == fleeing) // the info for what to do while fleeing
        {
            timeRetreating -= Time.deltaTime;
            transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            if (turning)
            {
                transform.Rotate(Vector3.up * turnSpeed * rotateDistance / 5);



            }

            if (timeRetreating <= 0)
            {
                status = previousCondition;
                isRetreating = false;

            }

        }

        // aims at player when targeting is true
        if (targetingPlayer)
        {
            transform.LookAt(playerLocation);
            playerLocation = GameObject.FindWithTag("Player").transform;


        }

        // checks if any nearby soldiers are raising Alarm
       /* var enemyAllies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject ally in enemyAllies)
        {
            var enemyLocation = ally.transform;
            var allyProximity = Vector3.Distance(enemyLocation.position, transform.position);
            AIWeaponuser aiwu = ally.GetComponent<AIWeaponuser>();
            var allyRadio = aiwu.radioChannel;
            var allyRaisingAlarm = aiwu.raisingAlarm;

            if (allyRadio == radioChannel && allyRaisingAlarm && !raisingAlarm)
            {
                awareOfPlayer = true;
                awarenessCooldown = forgetfulness;


            }




        }*/

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

        // firing cooldown
        if (firing)
        {
            firingCooldown += Time.deltaTime;



        }
    }

    void GuardingBehavior()
    {
        if (status == 1 || status == 6 || status == 7)
        {
            turning = !turning;
            walking = !walking;
            strafing = !strafing;
            rotateDistance = Random.Range(-5, 5);


        }
        print("Turning");
    }

    void PatrollingBehavior()
    {
        if (status == 2 || status == 5)
        {
            print("Patrolling");
            turning = !turning;
            walking = !walking;
            strafing = !strafing;



        }
        rotateDistance = Random.Range(-5, 5);


    }

    void StrafingBehavior()
    {
        if (status == 3 || status == 4)
        {
            walking = !walking;
            strafing = !strafing;
            turning = !turning;
            strafingDirection = Random.Range(-1, 1);


        }



    }

    public void HeardGunfire()
    {
        awareOfPlayer = true;
        awarenessCooldown = forgetfulness;


    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            awareOfPlayer = true;
            awarenessCooldown = forgetfulness;



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

    void OnCollisionStay (Collision other)
    {
        if (!flyingUnit)
        {
            isGrounded = true;


        }


    }
}
