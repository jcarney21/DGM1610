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

    public bool arcWeapon;
    public float bulletDrop;
    public float projVelocity;
    public float elevation;
    public float firingHeight;


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
        

        if (!target)
        {
            target = null;
            var fire = false;
            gameObject.GetComponent<Weapon>().OrdersToFire(fire);

        }

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

        if (target && arcWeapon)
        {
            //var targetParent = target.transform.parent.gameObject;
            targetLoc = target.transform;
            
            projVelocity = gameObject.GetComponent<Weapon>().velocityms;
            var rangefinder = Vector3.Distance(targetLoc.position, transform.position);
            var hitTime = rangefinder / projVelocity;
            var fallTime = firingHeight / bulletDrop;
            print(rangefinder);

            if (hitTime >= fallTime)
            {
                
                elevation =  Mathf.Asin((bulletDrop * rangefinder) / (projVelocity * projVelocity)) * 1/2 * Mathf.Rad2Deg;
                gameObject.GetComponent<Weapon>().RangeFinder(elevation);
                if (float.IsNaN(elevation))
                {
                    
                    var fire = false;
                    gameObject.GetComponent<Weapon>().OrdersToFire(fire);
                    print("out of range");
                }
            }
            


        }

        if (targeting)
        {
            var unitPos = transform.position;
            if (target)
            {
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
            }
            //targetLoc = target.transform;
            //var difference = targetLoc.position - unitPos;

            /*if ((Vector3.Angle(difference, transform.forward) < acceptableTargetDeviation))
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

            transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, difference, step, 0.0f));*/

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
