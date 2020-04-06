using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeSpawner : MonoBehaviour
{
    public GameObject fragGrenade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Instantiate(fragGrenade, transform.position, transform.rotation);


        }

    }
}
