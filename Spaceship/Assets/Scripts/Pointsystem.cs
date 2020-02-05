using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointsystem : MonoBehaviour
{

    public int score;
    public int pointsToAdd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Current score: " + score);

    }

    void OnTriggerEnter(Collider other)
    {
        score = score + pointsToAdd;
        

    }
}
