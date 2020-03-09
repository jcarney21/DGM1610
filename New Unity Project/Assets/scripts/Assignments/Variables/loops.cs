using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loops : MonoBehaviour
{
    public int numenemies = 5;
    public int cupsInSink = 10;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numenemies; i++)
        {
            Debug.Log("Enemy Number" + numenemies);
            

        }

        while (cupsInSink > 0)
        {
            Debug.Log("Washed a Cup");
            cupsInSink --;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
