using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{

    public int ammoToAdd;
    public GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            //WeaponManager.AmmoPickup(ammoToAdd);
            //weapon = GameObject.FindWithTag("Weapon");
           // WeaponManager wm = weapon.GetComponent<WeaponManager>();
            //bool isActiveWeapon = weapon.GetComponent<WeaponManager>();

            /*if (isActiveWeapon)
            {
                wm.AmmoPickup(ammoToAdd);


            }*/
        }
        


    }


}
