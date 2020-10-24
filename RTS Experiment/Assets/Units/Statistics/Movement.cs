using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3 waypoint;
    public GameObject target;
    public Transform targetLoc;

    public float movementSpeed;
    public bool accelerates;
    public float movementRotation;
    public int orders;

    public float acceptableTargetDeviation;


    private bool moving;
    public bool targeting;

    private GameObject unitController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if (accelerates)
            {


            }
            else if (!accelerates)
            {
                transform.Translate (Vector3.forward * movementSpeed * Time.deltaTime);


            }
            


        }

        if (targeting)
        {
            var unitPos = transform.position;
            targetLoc = target.transform;
            var difference = targetLoc.position - unitPos;

            if ((Vector3.Angle(difference, transform.forward) < acceptableTargetDeviation))
            {
                var fire = true;
                gameObject.GetComponent<Weapon>().OrdersToFire(fire);

            }
            else
            {
                var fire = false;
                gameObject.GetComponent<Weapon>().OrdersToFire(fire);
            }

            var step = movementRotation * Time.deltaTime;

            transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, difference, step, 0.0f));

            /*if ((Vector3.Angle(difference, transform.forward)) > 1 && (Vector3.Angle(difference, transform.forward)) < 180)
            {
                transform.Rotate(Vector3.up * movementRotation);

            }
            else if ((Vector3.Angle(difference, transform.forward)) > 180)
            {
                transform.Rotate(Vector3.down * movementRotation);

            }*/
            //transform.LookAt(target.transform.position);
            //transform.Rotate(Vector3.up * movementRotation);


        }
    }

    public void SetTarget (GameObject threat)
    {
        target = threat;

    }
    /*public void SetUnitController (GameObject controller)
    {
        unitController = controller;

    }*/
}
