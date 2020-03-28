using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyAI : MonoBehaviour
{
    // this stuff decides what weapon it's holding
    public float weaponProximity;
    public Transform wepLocation;

    public GameObject targetedEnemy;
    public Transform playerLocation;
    public Transform enemyLocation;
    public Transform patrolLocation;

    public float nearestEnemyProximity;
    public float proximity;
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
    public bool willingToFollowPlayer;
    public float patrolDistance;
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
    public float distanceFromEnemy;
    public bool isGrounded;

    // status data
    enum Status { guarding = 1, patrolling, attacking, cautiousAttacking, defending, retreating, fleeing, followingPlayer}
    Status status;
    Status previousCondition;
    Status firstCondition;
    //private int guarding = 1;
    //private int patrolling = 2;
    //private int followingPlayer = 8;
    //private int attacking = 3;
    //private int cautiousAttacking = 4;
    //private int defending = 5;
    //private int retreating = 6;
    //private int fleeing = 7;

    // for deciding if it knows about the player

    public bool awareOfPlayer;
    public bool awareOfEnemy;
    public bool canSeeEnemy;
    public bool targetingEnemy;

    // what is it acting
    public bool isRetreating;

    public Vector3 enemyLastLocation;

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
    public float playerAwarenessCooldown;
    // Start is called before the first frame update
    void Start()
    {
        status = Status.guarding;


        InvokeRepeating("GuardingBehavior", 5.0f, 3f);




        InvokeRepeating("PatrollingBehavior", 0.1f, 3f);



        previousCondition = status;
        firstCondition = status;
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
            awareOfEnemy = true;
            awarenessCooldown = forgetfulness;


        }

        // for raycasting. I found it in a Unity tutorial or something
        var player = GameObject.FindWithTag("Player");
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var enemy in enemies)
        {
            enemyLocation = enemy.transform;
            proximity = Vector3.Distance(enemyLocation.position, transform.position);
            if (proximity < nearestEnemyProximity)
            {
                targetedEnemy = enemy;
                nearestEnemyProximity = proximity;


            }




        }
        RaycastHit hit;
        //Ray lineOfSight = new Ray(transform.position, Vector3.forward);
        Vector3 rayDirection = targetedEnemy.transform.position - transform.position;


        // all of this helps the Ai determine if it can see the enemy
        if ((Vector3.Angle(rayDirection, transform.forward)) < fieldOfViewRange)
        {
            if (Physics.Raycast(transform.position, rayDirection, out hit, sightDistance))
            {
                if (hit.transform.CompareTag("Player"))
                {

                    awareOfPlayer = true;
                    playerAwarenessCooldown = forgetfulness;
                    
                }

                else if (hit.transform.CompareTag("Enemy"))
                {
                    awareOfEnemy = true;
                    awarenessCooldown = forgetfulness;
                    enemyLastLocation = enemy.transform.position;
                    canSeeEnemy = true;
                }

                else
                {
                    canSeeEnemy = false;

                }



            }




        }

        // this decides when the AI forgets the player and moves to its previous status
        if (!canSeeEnemy && awareOfEnemy)
        {
            awarenessCooldown -= Time.deltaTime;


        }

        if (awarenessCooldown <= 0 && awareOfEnemy)
        {
            awareOfEnemy = false;
            status = previousCondition;
            //raisingAlarm = false;

        }

        if (playerAwarenessCooldown <= 0 && awareOfPlayer && !awareOfEnemy)
        {
            awareOfPlayer = false;
            status = firstCondition;


        }
        if (awareOfPlayer && willingToFollowPlayer && !awareOfEnemy)
        {
            status = followingPlayer;







        }




        // aims at player when targeting is true
        if (targetingEnemy)
        {
            transform.LookAt(enemyLocation);
            enemyLocation = GameObject.FindWithTag("Enemy").transform;


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
}
