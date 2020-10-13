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

    public int ammunition; // Maybe? No, it has been incorporated into Weapon script

    // Unit Components
    public float unitRadius;//

    public GameObject soldier1;//
    public GameObject soldier2;//
    public GameObject soldier3;//
    public GameObject soldier4;//
    public GameObject soldier5;//
    public GameObject soldier6;//

    public float health1;//
    public float health2;//
    public float health3;//
    public float health4;//
    public float health5;//
    public float health6;//

    // Start is called before the first frame update
    void Start()
    {
        //Health Monitoring
        var h1 = soldier1.GetComponent <Health> ();
        health1 = h1.health;
        var h2 = soldier2.GetComponent<Health>();
        health2 = h2.health;
        var h3 = soldier3.GetComponent<Health>();
        health3 = h3.health;
        var h4 = soldier4.GetComponent<Health>();
        health4 = h4.health;
        var h5 = soldier5.GetComponent<Health>();
        health5 = h5.health;
        var h6 = soldier6.GetComponent<Health>();
        health6 = h6.health;



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
        health = 0;
        if (soldier1)
        {
            health += soldier1.GetComponent<Health>().health;
        }
        if (soldier2)
        {
            health += soldier2.GetComponent<Health>().health;
        }
        if (soldier3)
        {
            health += soldier3.GetComponent<Health>().health;
        }
        if (soldier4)
        {
            health += soldier4.GetComponent<Health>().health;
        }
        if (soldier5)
        {
            health += soldier5.GetComponent<Health>().health;
        }
        //var h2 = soldier2.GetComponent<Health>();
        //health += h2.health;
        if (soldier6)
        {
            var h6 = soldier6.GetComponent<Health>();
            health += h6.health;
        }


        //health = health1 + health2 + health3 + health4 + health5 + health6;
        print(health);




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
