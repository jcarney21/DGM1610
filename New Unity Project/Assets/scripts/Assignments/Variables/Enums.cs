using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums : MonoBehaviour
{
    public string favHero = "Batman";
    public float smarts;

    enum Days{sun = 1, mon, tues, wed, thurs, fri, sat };
    Days currentDay;
    // Start is called before the first frame update
    void Start()
    {
        currentDay = Days.sun;
        switch (favHero)
        {
            case "Superman":
                print("Wrong");
                break;
            case "Thor":
                print("Correct");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (smarts)
        {
            case 1:

                break;
            case 5:

                break;
            default:
                print("Derp");
                break;


        }
        if(currentDay == Days.mon)
        {
            print("Go back to bed");


        }
    }
}
