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

    public float damageMultiplier;

    public bool splash;
    public float splashRadius;
    public float splashDamage;
    public float splashShields;

    public float velocity;
    public float arcVelocity;
    public float acceleration;

    Rigidbody rb;

    public float spawnTime;


    // Start is called before the first frame update
    void Start()
    {
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
}
