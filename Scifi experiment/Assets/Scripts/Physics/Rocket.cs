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

    public float specificFuelConsumption;

    public float standardGravity = 9.80665f;

    public float wetMass;
    public float dryMass;

    public Rigidbody rb;
    private Fuel fe;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        fe = gameObject.GetComponent<Fuel>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // Communication with other scripts
        //specificFuelConsumption = fe.specificFuelConsumption;
        massFlowRoe = fe.lfUsageRate;
        wetMass = dryMass + fe.lf + fe.oxydizer;

        // thrust and acceleration
        //thrust = exhaustGas * massFlowRoe; (If I want thrust to be calculated)

            //specificFuelConsumption = massFlowRoe / thrust;
        acceleration = thrust / wetMass;

        rb.AddRelativeForce(Vector3.forward * acceleration * throttle);

        //Specific Impulse
            //specificImpulse = 3600 / specificFuelConsumption;
             //specificImpulse = thrust / massFlowRoe;
        exhaustGas = specificImpulse;

        // Rocket Equation
        deltaV = specificImpulse * standardGravity * Mathf.Log(wetMass / dryMass);

        // Throttle
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
