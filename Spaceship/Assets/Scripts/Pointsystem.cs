﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointsystem : MonoBehaviour
{

    public static int score;
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Current score: " + score);

    }

    public static void AddPoints(int pointsToAdd)
    {
        score = score + pointsToAdd;


    }
}
