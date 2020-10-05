using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int playerFaction;
    public static int supplyMax;

    // Player 1
    public static int p1Supply;
    public static int p1MaxSupply;

    public static int fac1Resource1;
    public static int fac1Resource2;
    public static int fac1Resource3;

    // Player 2
    public static int p2Supply;
    public static int p2MaxSupply;

    public static int fac2Resource1;
    public static int fac2Resource2;
    public static int fac2Resource3;

    // Player 3
    public static int p3Supply;
    public static int p3MaxSupply;

    public static int fac3Resource1;
    public static int fac3Resource2;
    public static int fac3Resource3;

    // Player 4
    public static int p4Supply;
    public static int p4MaxSupply;

    public static int fac4Resource1;
    public static int fac4Resource2;
    public static int fac4Resource3;

    // Player 5
    public static int p5Supply;
    public static int p5MaxSupply;

    public static int fac5Resource1;
    public static int fac5Resource2;
    public static int fac5Resource3;

    // Player 6
    public static int p6Supply;
    public static int p6MaxSupply;

    public static int fac6Resource1;
    public static int fac6Resource2;
    public static int fac6Resource3;

    // Player 7
    public static int p7Supply;
    public static int p7MaxSupply;

    public static int fac7Resource1;
    public static int fac7Resource2;
    public static int fac7Resource3;

    // Player 8
    public static int p8Supply;
    public static int p8MaxSupply;

    public static int fac8Resource1;
    public static int fac8Resource2;
    public static int fac8Resource3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void AddSupply1 (supply)
    {
        p1Supply += supply;


    }
}
