using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMovement : MonoBehaviour
{

    public float forwardInput;
    public float throttle;
    public float enginethrust;
    public float currentThrust;
    public float mass;
    public float twr;
    public float velocity;
    public float acceleration;
    public float rotateInput;
 



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        throttle = (throttle + forwardInput);
        throttle = Mathf.Clamp(throttle, 0f, 100f);
        currentThrust = enginethrust * (throttle/100f);
        twr = enginethrust / mass;
        velocity = velocity + (currentThrust/mass *Time.deltaTime);
        acceleration = currentThrust / mass;
        

        transform.Translate(Vector3.back * velocity *Time.deltaTime);

        rotateInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * rotateInput);

    }
}
