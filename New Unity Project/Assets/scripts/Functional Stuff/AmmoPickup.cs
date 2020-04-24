using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{

    public int ammoToAdd;
    public string ammoType;
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
            var weapons = GameObject.FindGameObjectsWithTag("Weapon");
            foreach (GameObject weapon in weapons)
            {
                var weaponloc = weapon.transform;
                var proximity = Vector3.Distance(weaponloc.position, transform.position);
                var weaponString = weapon.name;
                WeaponManager wm = weapon.GetComponent<WeaponManager>();
                //var weaponString = wm.weaponName;

                if (ammoType == weaponString && proximity < 3)
                {
                    wm.AmmoPickup(ammoToAdd);
                    Destroy(gameObject);


                }

            }

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
