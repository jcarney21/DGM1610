using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    public float lf;
    public float oxydizer;
    public float lfoRatio;

    public float lfUsageRate;
    public float oxydizerUsageRate;
    public float coolant;

    public float maxlf;
    public float maxoxydizer;
    public float burnTime;

    //public float specificFuelConsumption;
    //public float staticThrust;

    private float throttle;
    private Rocket rt;
    // Start is called before the first frame update
    void Start()
    {
        rt = gameObject.GetComponent<Rocket>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        var thrust = rt.thrust;
        var specificImpulse = rt.specificImpulse;


        throttle = rt.throttle;

        //lfUsageRate = maxlf / burnTime; //staticThrust * specificFuelConsumption; (if I want thrust to be calculated)
        lfUsageRate = thrust / (specificImpulse * 9.81f);
        oxydizerUsageRate = lfUsageRate * lfoRatio;

        burnTime = lf / lfUsageRate;

        if (throttle > 0)
        {
            lf -= (lfUsageRate * throttle);



        }
    }
}
