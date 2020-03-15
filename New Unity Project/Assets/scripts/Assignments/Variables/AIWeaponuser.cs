using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWeaponuser : MonoBehaviour
{
    public float weaponProximity;
    public Transform wepLocation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        var weapons = GameObject.FindGameObjectsWithTag("Weapon");
        foreach (GameObject weapon in weapons)
        {
            wepLocation = weapon.transform;
            weaponProximity = Vector3.Distance(wepLocation.position, transform.position);
            WeaponManager wm = weapon.GetComponent<WeaponManager>();
            bool heldByEnemy = wm;
            if (weaponProximity < 2 && heldByEnemy)
            {
                wm.Fire();


            }

        }
    }
}
