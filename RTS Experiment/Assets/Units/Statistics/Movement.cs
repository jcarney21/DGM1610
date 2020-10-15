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
            targetLoc = target.transform;

            if (!target)
            {

                unitController.GetComponent<Targeting>().Unit1LostTarget();

            }

            transform.LookAt(targetLoc);
            transform.Rotate(Vector3.up * movementRotation);


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
