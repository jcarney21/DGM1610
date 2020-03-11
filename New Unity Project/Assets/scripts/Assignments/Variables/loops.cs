using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loops : MonoBehaviour
{
    //public int numenemies = 5;
    public int cupsInSink = 10;


    // Start is called before the first frame update
    void Start()
    {
        /*for (int i = 0; i < numenemies; i++)
        {
            Debug.Log("Enemy Number" + numenemies);
            

        }*/

        while (cupsInSink > 0)
        {
            Debug.Log("Washed a Cup");
            cupsInSink --;

        }

        /*bool shouldContinue = false;

        do
        {
            print("HelloWorld");

        } while (shouldContinue == true);*/

        //for each loop
        string[] strings = new string[4];
        strings[0] = "First string";
        strings[1] = "Second string";
        strings[2] = "Third string";

        foreach (string item in strings)
        {
            print(item);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
