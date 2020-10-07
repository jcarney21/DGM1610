using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitData : MonoBehaviour
{
    //Selection and Faction Data
    public bool isSelected;//
    public int faction;
    public bool isSelectable;

    public int playerFaction;

    public int selectingFaction;//

    public Vector3 Waypoint;//
    public object Target;//
    public int order;//

    // Stats
    public string unitName;//
    public string unitTags;//
    public float maxhealth;
    public float health;

    public int supply;
    public int resource1;//
    public int resource2;//
    public int resource3;//

    public int ammunition; // Maybe

    // Unit Components
    public float unitRadius;//

    public object soldier1;//
    public object soldier2;//
    public object soldier3;//
    public object soldier4;//
    public object soldier5;//
    public object soldier6;//

    public float health1;//
    public float health2;//
    public float health3;//
    public float health4;//
    public float health5;//
    public float health6;//

    // Start is called before the first frame update
    void Start()
    {
        maxhealth = health1 + health2 + health3 + health4 + health5 + health6;

        if (faction == playerFaction)
        {
            isSelectable = true;



        }
        else
        {
            isSelectable = false;

        }


        // Supplies on Spawn
        if (faction == 1)
        {
            GameManager.AddSupply1 (supply);


        }
        else if (faction == 2)
        {
            GameManager.AddSupply2(supply);


        }
        else if (faction == 3)
        {
            GameManager.AddSupply3(supply);


        }
        else if (faction == 4)
        {
            GameManager.AddSupply4(supply);


        }
        else if (faction == 5)
        {
            GameManager.AddSupply5(supply);


        }
        else if (faction == 6)
        {
            GameManager.AddSupply6(supply);


        }
        else if (faction == 7)
        {
            GameManager.AddSupply7(supply);


        }
        else if (faction == 8)
        {
            GameManager.AddSupply8(supply);


        }


    }

    // Update is called once per frame
    void Update()
    {

        //health manager

        health = health1 + health2 + health3 + health4 + health5 + health6;


            // Death Manager
        if (health <= 0)
        {
            if (faction == 1)
            {
                GameManager.Subtract1(supply);



            }
            else if (faction == 2)
            {
                GameManager.Subtract2(supply);



            }
            else if (faction == 3)
            {
                GameManager.Subtract3(supply);



            }
            else if (faction == 4)
            {
                GameManager.Subtract4(supply);



            }
            else if (faction == 5)
            {
                GameManager.Subtract5(supply);



            }
            else if (faction == 6)
            {
                GameManager.Subtract6(supply);



            }
            else if (faction == 7)
            {
                GameManager.Subtract7(supply);



            }
            else if (faction == 8)
            {
                GameManager.Subtract8(supply);



            }
            else
            {

            }


            Destroy(gameObject);




        }
    }
}
