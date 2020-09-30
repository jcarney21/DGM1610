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
    public float health;//

    public int supply;//
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
        health = health1 + health2 + health3 + health4 + health5 + health6;

        if (faction == playerFaction)
        {
            isSelectable = true;



        }
        else
        {
            isSelectable = false;

        }
    }

    // Update is called once per frame
    void Update()
    {
        health = health1 + health2 + health3 + health4 + health5 + health6;
    }
}
