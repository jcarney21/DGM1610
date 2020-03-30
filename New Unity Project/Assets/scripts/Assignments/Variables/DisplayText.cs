using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    public Text shieldText;
    public Text healthText;
    //public Text pickupWeapon;
    public Text scoreText;
    //private GameObject weaponHeld;

    //public int winScore;
    //public Text winText;
    //public Text ammoText;
    //public Text magazineText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*var weapons = GameObject.FindGameObjectsWithTag("Weapon");
        foreach (GameObject weapon in weapons)
        {
            
            WeaponManager wm = weapon.GetComponent<WeaponManager>();
            var isActiveWeapon = wm.isActiveWeapon;
            if (isActiveWeapon)
            {
                weaponHeld = weapon;



            }


        }

        WeaponManager hw = weaponHeld.GetComponent<WeaponManager>();
        int magazineAmmo = hw.magazine;
        int fullAmmo = hw.ammoCarrying;
        */

        //var isActiveWeapon = WeaponManager.currentlyActive;
        var displayHealth = Move.health;
        float displayShields = Move.shields;
        var score = ScoreManager.score;

        healthText.text = "Health: " + displayHealth;
        shieldText.text = "Shields: " + displayShields;
        scoreText.text = "Score: " + score;
        //ammoText.text = "" + fullAmmo;
       // magazineText.text = " " + magazineAmmo;

        /*if (isActiveWeapon)
        {
            //var ammoInMag = WeaponManager.magazine;

            //ammoCounter.text = "Magazine: " + ammoInMag;
        }*/
    }
}
