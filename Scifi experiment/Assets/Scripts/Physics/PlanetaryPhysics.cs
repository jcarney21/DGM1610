using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryPhysics : MonoBehaviour
{
    
    public GameObject star;

    public float mass;

    public float mass2;

    public float distance;
    public float gravity;
    public float velocity;

    public float initialVelocity;

    Rigidbody rb;
    public Vector3 previousPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.left * initialVelocity);


        distance = Vector3.Distance(star.transform.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        var sp = star.GetComponent<PlanetaryPhysics>();
        mass2 = sp.mass;
    }

    void FixedUpdate()
    {

        //Calculates Gravity
        distance = Vector3.Distance(star.transform.position, transform.position);
        gravity = (mass * mass2) / (distance * distance);
        rb.AddForce((star.transform.position - transform.position).normalized * gravity);

        //Calculates Current Velocity
        velocity = (transform.position - previousPosition).magnitude;
        previousPosition = transform.position;
    }
}
