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

    //public int damageType;//

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DealDamage(float damage, float shieldDamage, int damageType)
    {
        if (shields > 0)
        {
            shields -= (shieldDamage - shieldArmor);



        }



    }
}
