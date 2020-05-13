using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // Thrust Calculator

    public float thrust;

    public float exhaustGas;
    public float massFlowRoe;

    public float acceleration; //meters/second^2

    public float throttle;
    // Rocket Equation
    public float deltaV; // m/s^2

    public float specificImpulse;
    public float standardGravity = 9.80665f;

    public float wetMass;
    public float dryMass;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        

        // thrust and acceleration
        thrust = exhaustGas * massFlowRoe;

        acceleration = thrust / wetMass;

        rb.AddRelativeForce(Vector3.forward * acceleration * throttle);

        // Rocket Equation
        deltaV = specificImpulse * standardGravity * Mathf.Log(wetMass / dryMass);


        if (Input.GetKeyDown(KeyCode.Z))
        {
            throttle = 1;


        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            throttle = 0;


        }
    }
}
