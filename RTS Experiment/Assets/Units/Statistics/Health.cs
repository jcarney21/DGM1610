using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;//
    public float armor;//
    public int resistance;
    public int weakness;

    public float shields;//
    public float shieldArmor;//
    public int shieldResist;
    public int shieldWeak;

    public float damageMod;
    public float shieldMod;

    //public int damageType;//

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage(float damage, float shieldDamage, int damageType, float resistFactor, float weakFactor)
    {
        // Determines if the unit armor is resistant or weak to weapon
        if (damageType == resistance)
        {
            damageMod = -resistFactor;


        }
        else if (damageType == weakness)
        {
            damageMod = weakFactor;

        }
        else
        {
            damageMod = 0;

        }

        // Determines if unit shields are resistant or weak to weapon
        if (damageType == shieldResist)
        {
            shieldMod = -resistFactor;


        }
        else if (damageType == shieldWeak)
        {
            shieldMod = weakFactor;


        }
        else
        {
            shieldMod = 0;
        }

        //Actual Damage-dealing
        if (shields > 0)
        {
            if ((shieldDamage + shieldMod) -shieldArmor > 0)
            {
                shields -= ((shieldDamage + shieldMod) - shieldArmor);


            }
            else if ((shieldDamage + shieldMod) - shieldArmor <= 0)
            {
                shields -= 1;


            }
            
            if (shields < 0)
            {
                shields = 0;


            }


        }
        else if (shields <= 0)
        {
            if ((damage + damageMod) - armor > 0)
            {
                health -= ((damage + damageMod) - armor);



            }
            else if ((damage + damageMod) - armor <= 0)
            {
                health -= 1;


            }




        }



    }
}
