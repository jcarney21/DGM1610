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
        if (damageType == resistance)
        {
            damageMod = 0 - resistFactor;


        }
        else if (damageType == weakness)
        {
            damageMod += weakFactor;

        }
        else
        {
            damageMod = 0;

        }


        if (shields > 0)
        {
            if ((shieldDamage + damageMod) -shieldArmor > 0)
            {
                shields -= ((shieldDamage + damageMod) - shieldArmor);


            }
            else if ((shieldDamage + damageMod) - shieldArmor <= 0)
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
