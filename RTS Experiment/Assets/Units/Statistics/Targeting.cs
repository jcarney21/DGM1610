using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    public GameObject target;

    public GameObject soldier1;//
    public GameObject soldier2;//
    public GameObject soldier3;//
    public GameObject soldier4;//
    public GameObject soldier5;//
    public GameObject soldier6;//

    public GameObject hostileSoldier1;
    public GameObject hostileSoldier2;
    public GameObject hostileSoldier3;
    public GameObject hostileSoldier4;
    public GameObject hostileSoldier5;
    public GameObject hostileSoldier6;

    // Start is called before the first frame update
    void Start()
    {
        soldier1 = gameObject.GetComponent<UnitData>().soldier1;
        soldier2 = gameObject.GetComponent<UnitData>().soldier2;
        soldier3 = gameObject.GetComponent<UnitData>().soldier3;
        soldier4 = gameObject.GetComponent<UnitData>().soldier4;
        soldier5 = gameObject.GetComponent<UnitData>().soldier5;
        soldier6 = gameObject.GetComponent<UnitData>().soldier6;
    }

    // Update is called once per frame
    void Update()
    {
        hostileSoldier1 = target.GetComponent<UnitData>().soldier1;
        hostileSoldier2 = target.GetComponent<UnitData>().soldier2;
        hostileSoldier3 = target.GetComponent<UnitData>().soldier3;
        hostileSoldier4 = target.GetComponent<UnitData>().soldier4;
        hostileSoldier5 = target.GetComponent<UnitData>().soldier5;
        hostileSoldier6 = target.GetComponent<UnitData>().soldier6;

        /*if (soldier1)
        {
            var random = Random.Range(1, 6);
            if(random == 1 && hostileSoldier1)
            {
                var threat = hostileSoldier1;
                soldier1.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 2 && hostileSoldier2)
            {
                var threat = hostileSoldier2;
                soldier1.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 3 && hostileSoldier3)
            {
                var threat = hostileSoldier3;
                soldier1.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 4 && hostileSoldier4)
            {
                var threat = hostileSoldier4;
                soldier1.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 5 && hostileSoldier5)
            {
                var threat = hostileSoldier5;
                soldier1.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 6 && hostileSoldier6)
            {
                var threat = hostileSoldier6;
                soldier1.GetComponent<Movement>().SetTarget(threat);
            }




        }*/
    }

    public void Unit1LostTarget()
    {
        var random = Random.Range(1, 6);
        if (random == 1 && hostileSoldier1)
        {
            var threat = hostileSoldier1;
            soldier1.GetComponent<Movement>().SetTarget(threat);
        }
        else if (random == 2 && hostileSoldier2)
        {
            var threat = hostileSoldier2;
            soldier1.GetComponent<Movement>().SetTarget(threat);
        }
        else if (random == 3 && hostileSoldier3)
        {
            var threat = hostileSoldier3;
            soldier1.GetComponent<Movement>().SetTarget(threat);
        }
        else if (random == 4 && hostileSoldier4)
        {
            var threat = hostileSoldier4;
            soldier1.GetComponent<Movement>().SetTarget(threat);
        }
        else if (random == 5 && hostileSoldier5)
        {
            var threat = hostileSoldier5;
            soldier1.GetComponent<Movement>().SetTarget(threat);
        }
        else if (random == 6 && hostileSoldier6)
        {
            var threat = hostileSoldier6;
            soldier1.GetComponent<Movement>().SetTarget(threat);
        }


    }
}
