﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    public Text shieldText;
    public Text healthText;
    //public Text pickupWeapon;
    public Text scoreText;
   // public Text ammoCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //var isActiveWeapon = WeaponManager.currentlyActive;
        var displayHealth = Move.health;
        float displayShields = Move.shields;
        var score = ScoreManager.score;
        healthText.text = "Health: " + displayHealth;
        shieldText.text = "Shields: " + displayShields;
        scoreText.text = "Score: " + score;

        /*if (isActiveWeapon)
        {
            //var ammoInMag = WeaponManager.magazine;

            //ammoCounter.text = "Magazine: " + ammoInMag;
        }*/
    }
}
