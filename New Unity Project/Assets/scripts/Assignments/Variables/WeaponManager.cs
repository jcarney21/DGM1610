using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public float weaponDmg;
    public int magazine;
    public int ammoCarrying;
    public int ammoMax;
    public float fireCycle;
    public float rateOfFire;
    public float proximityToPlayer;


    public bool autoFire;
    public bool isActiveWeapon;
    public bool isHoldingWeapon;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {




        if (isHoldingWeapon == true)
        {
            if (isActiveWeapon == false)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    isActiveWeapon = true;


                }


            }

            else if (isActiveWeapon == true)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    isActiveWeapon = false;


                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    isHoldingWeapon = false;



                }


            }

        }

        else if (isHoldingWeapon == false)
        {
            if (proximityToPlayer < 2)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    isHoldingWeapon = true;
                    isActiveWeapon = true;


                }



            }


        }
    }
}
