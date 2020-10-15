using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float shieldDamage;
    public int damageType;
    // 0 Equals Normal Bullet
    // 1 Equals Armor Piercing
    // 2 Equals HE
    // 3 Equals APHE
    // 4 Equals Incindiary
    // 5 Equals Emp-Capped
    // 6 Equals Shrapnel
    // 7 Equals Subcaliber Supersonic

    // 8 Equals SuperHeated DEW
    // 9 Equals Kinetic DEW
    // 10 Equals Energy Transfer DEW
    // 11 Equals Explosive Shock DEW
    // 12 Equals Laser DEW

    // 13 Equals Slug (think like a musketshot)
    // 14 Equals Spikelauncher (Think like a supersonic Arrow)
    // 15 

    // What if I did a dynamic damage model based on caliber and velocity. That could be cool, but...

    public bool splash;
    public float splashRadius; // Note: anything beyond 2 or 3 is probably unreasonably large
    public float splashDamage;
    public float splashShields;

    public float velocity;
    public float arcVelocity;
    public float acceleration;

    Rigidbody rb;

    public float spawnTime;

    public float clearance;

    // Start is called before the first frame update
    void Start()
    {
        if(clearance >= 0)
        {
            clearance = .1f;


        }
        transform.Translate (Vector3.forward * clearance);

        Destroy(gameObject, spawnTime);
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * velocity);
        rb.AddForce(transform.up * arcVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {

        if (acceleration != 0)
        {
            rb.AddForce(transform.forward * acceleration);


        }
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Health>())
        {
            other.gameObject.GetComponent<Health>().DealDamage(damage, shieldDamage, damageType);


        }
        
        if (other.gameObject.CompareTag("Projectile"))
        {
            

        }
        else
        {
            Destroy(gameObject);


        }
        

        // splashDamage

        if (splash)
        {
            var st = GameObject.FindGameObjectsWithTag("Subunit");

            foreach (var target in st)
            {
                var proximity = Vector3.Distance(target.transform.position, transform.position);

                if (proximity <= splashRadius)
                {
                    target.gameObject.GetComponent<Health>().SplashDamage(splashDamage, splashShields, damageType);



                }


            }



        }

    }
}
