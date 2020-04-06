using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickup : Pickup
{
    public int rechargeToAdd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Move m = other.gameObject.GetComponent<Move>();
            m.AddRecharge(rechargeToAdd);
            Destroy(gameObject);


        }
    }
}
