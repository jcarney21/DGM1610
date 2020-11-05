using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : MonoBehaviour
{
    public Vector3 waypoint;
    public GameObject waypointStandin;

    public float movement;
    public bool accelerates;
    public float acceleration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waypoint = waypointStandin.transform.position;

        if (!accelerates)
        {
            float step = movement * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, waypoint, step);


        }
    }
}
