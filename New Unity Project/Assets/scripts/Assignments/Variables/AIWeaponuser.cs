using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWeaponuser : MonoBehaviour
{
    public float weaponProximity;
    public Transform wepLocation;
    public Transform playerLocation;
    public float turnSpeed;

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
    public float firingFrequency;
    public float firingCooldown;

    // Start is called before the first frame update
    void Start()
    {
        status = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!awareOfPlayer)
        {
            if (status == 1)
            {
                int rotateDistance = Random.Range(-1, 1);
                for (int i = 0; i < 10; i++)
                {
                    transform.Rotate(Vector3.up * turnSpeed/4 * rotateDistance);


                }

                for (int i = 0; i < 6; i += (int) Time.deltaTime)
                {




                }



            }




        }
        else if (awareOfPlayer)
        {




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
            if (weaponProximity < 1 && firing)
            {
                wm.Fire();


            }

        }
    }
}
