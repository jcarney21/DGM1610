using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbits : MonoBehaviour
{
    public GameObject planet;

    public float mass;

    public float mass2;

    public float distance;
    public float gravity;
    public float velocity;

    public float initialVelocity;

    // Orbital Data
    public float apoapsis;
    public float pariapsis;
    public float inclination;
    

    Rigidbody rb;
    public Vector3 previousPosition;
    public Vector3 planetaryPrevious;
    public Vector3 correction;

    // Start is called before the first frame update
    void Start()
    {
        
         rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.left * initialVelocity);


        distance = Vector3.Distance(planet.transform.position, transform.position);
        pariapsis = distance;
    }

    // Update is called once per frame
    void Update()
    {
        var pp = planet.GetComponent<PlanetaryPhysics>();
        mass2 = pp.mass;

        

        if (distance > apoapsis)
        {
            apoapsis = distance;



        }
        else if (distance < pariapsis)
        {
            pariapsis = distance;


        }

    }

    void FixedUpdate()
    {
        // Corrects for Planetary Orbit
        correction = planet.transform.position - planetaryPrevious;
        planetaryPrevious = planet.transform.position;
        transform.position += correction;

        //Calculates Gravity
        distance = Vector3.Distance(planet.transform.position, transform.position);
        gravity = (mass * mass2) / (distance * distance);
        rb.AddForce((planet.transform.position - transform.position).normalized * gravity);

        //Calculates Current Velocity
        velocity = (transform.position - previousPosition).magnitude;
        previousPosition = transform.position;
    }
}
