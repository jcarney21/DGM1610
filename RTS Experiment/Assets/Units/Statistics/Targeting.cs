using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
    public GameObject target;

    public GameObject soldier1;//
    public GameObject target1;

    public GameObject soldier2;//
    public GameObject target2;

    public GameObject soldier3;//
    public GameObject target3;

    public GameObject soldier4;//
    public GameObject target4;

    public GameObject soldier5;//
    public GameObject target5;

    public GameObject soldier6;//
    public GameObject target6;

    public GameObject hostileSoldier1;
    public GameObject hostileSoldier2;
    public GameObject hostileSoldier3;
    public GameObject hostileSoldier4;
    public GameObject hostileSoldier5;
    public GameObject hostileSoldier6;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.GetComponent<UnitData>().soldier1)
        {
            soldier1 = gameObject.GetComponent<UnitData>().soldier1;

        }
        if (soldier2 = gameObject.GetComponent<UnitData>().soldier2)
        {
            soldier2 = gameObject.GetComponent<UnitData>().soldier2;

        }
        if (gameObject.GetComponent<UnitData>().soldier3)
        {
            soldier3 = gameObject.GetComponent<UnitData>().soldier3;

        }
        if (soldier4 = gameObject.GetComponent<UnitData>().soldier4)
        {
            soldier4 = gameObject.GetComponent<UnitData>().soldier4;

        }
        if (gameObject.GetComponent<UnitData>().soldier5)
        {
            soldier5 = gameObject.GetComponent<UnitData>().soldier5;

        }
        if (soldier6 = gameObject.GetComponent<UnitData>().soldier6)
        {
            soldier6 = gameObject.GetComponent<UnitData>().soldier6;

        }

        /*soldier2 = gameObject.GetComponent<UnitData>().soldier2;
        soldier3 = gameObject.GetComponent<UnitData>().soldier3;
        soldier4 = gameObject.GetComponent<UnitData>().soldier4;
        soldier5 = gameObject.GetComponent<UnitData>().soldier5;
        soldier6 = gameObject.GetComponent<UnitData>().soldier6;*/
    }

    // Update is called once per frame
    void Update()
    {
        // Monitors target Acquisition
        if (soldier1)
        {
            target1 = soldier1.GetComponent<Movement>().target;
        }
        if (soldier2)
        {
            target2 = soldier2.GetComponent<Movement>().target;
        }
        if (soldier3)
        {
            target3 = soldier3.GetComponent<Movement>().target;
        }
        if (soldier4)
        {
            target4 = soldier4.GetComponent<Movement>().target;
        }
        if (soldier5)
        {
            target5 = soldier5.GetComponent<Movement>().target;
        }
        if (soldier6)
        {
            target6 = soldier6.GetComponent<Movement>().target;
        }
        //target1 = soldier1.GetComponent<Movement>().target;
        //target2 = soldier1.GetComponent<Movement>().target;
        //target3 = soldier1.GetComponent<Movement>().target;
        //target4 = soldier1.GetComponent<Movement>().target;
        //target5 = soldier1.GetComponent<Movement>().target;
        //target6 = soldier1.GetComponent<Movement>().target;

        //Detects hostile subunits
        if (target && target.GetComponent<UnitData>().soldier1)
        {
            hostileSoldier1 = target.GetComponent<UnitData>().soldier1;

        }
        if (target && target.GetComponent<UnitData>().soldier2)
        {
            hostileSoldier2 = target.GetComponent<UnitData>().soldier2;

        }
        if (target && target.GetComponent<UnitData>().soldier3)
        {
            hostileSoldier3 = target.GetComponent<UnitData>().soldier3;

        }
        if (target && target.GetComponent<UnitData>().soldier4)
        {
            hostileSoldier4 = target.GetComponent<UnitData>().soldier4;

        }
        if (target && target.GetComponent<UnitData>().soldier5)
        {
            hostileSoldier5 = target.GetComponent<UnitData>().soldier5;

        }
        if (target && target.GetComponent<UnitData>().soldier6)
        {
            hostileSoldier6 = target.GetComponent<UnitData>().soldier6;

        }
        /*hostileSoldier2 = target.GetComponent<UnitData>().soldier2;
        hostileSoldier3 = target.GetComponent<UnitData>().soldier3;
        hostileSoldier4 = target.GetComponent<UnitData>().soldier4;
        hostileSoldier5 = target.GetComponent<UnitData>().soldier5;
        hostileSoldier6 = target.GetComponent<UnitData>().soldier6;*/

        //Actual target assignment
        if (soldier1 && target1 == null)
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
            else
            {
                GameObject threat = null;
                soldier1.GetComponent<Movement>().SetTarget(threat);
            }
        }

        if (soldier2 && target2 == null)
        {
            var random = Random.Range(1, 6);
            if (random == 1 && hostileSoldier1)
            {
                var threat = hostileSoldier1;
                soldier2.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 2 && hostileSoldier2)
            {
                var threat = hostileSoldier2;
                soldier2.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 3 && hostileSoldier3)
            {
                var threat = hostileSoldier3;
                soldier2.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 4 && hostileSoldier4)
            {
                var threat = hostileSoldier4;
                soldier2.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 5 && hostileSoldier5)
            {
                var threat = hostileSoldier5;
                soldier2.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 6 && hostileSoldier6)
            {
                var threat = hostileSoldier6;
                soldier2.GetComponent<Movement>().SetTarget(threat);
            }
            else
            {
                GameObject threat = null;
                soldier2.GetComponent<Movement>().SetTarget(threat);
            }
        }

        if (soldier3 && target3 == null)
        {
            var random = Random.Range(1, 6);
            if (random == 1 && hostileSoldier1)
            {
                var threat = hostileSoldier1;
                soldier3.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 2 && hostileSoldier2)
            {
                var threat = hostileSoldier2;
                soldier3.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 3 && hostileSoldier3)
            {
                var threat = hostileSoldier3;
                soldier3.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 4 && hostileSoldier4)
            {
                var threat = hostileSoldier4;
                soldier3.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 5 && hostileSoldier5)
            {
                var threat = hostileSoldier5;
                soldier3.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 6 && hostileSoldier6)
            {
                var threat = hostileSoldier6;
                soldier3.GetComponent<Movement>().SetTarget(threat);
            }
            else
            {
                GameObject threat = null;
                soldier3.GetComponent<Movement>().SetTarget(threat);
            }
        }

        if (soldier4 && target4 == null)
        {
            var random = Random.Range(1, 6);
            if (random == 1 && hostileSoldier1)
            {
                var threat = hostileSoldier1;
                soldier4.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 2 && hostileSoldier2)
            {
                var threat = hostileSoldier2;
                soldier4.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 3 && hostileSoldier3)
            {
                var threat = hostileSoldier3;
                soldier4.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 4 && hostileSoldier4)
            {
                var threat = hostileSoldier4;
                soldier4.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 5 && hostileSoldier5)
            {
                var threat = hostileSoldier5;
                soldier4.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 6 && hostileSoldier6)
            {
                var threat = hostileSoldier6;
                soldier4.GetComponent<Movement>().SetTarget(threat);
            }
            else
            {
                GameObject threat = null;
                soldier4.GetComponent<Movement>().SetTarget(threat);
            }
        }

        if (soldier5 && target5 == null)
        {
            var random = Random.Range(1, 6);
            if (random == 1 && hostileSoldier1)
            {
                var threat = hostileSoldier1;
                soldier5.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 2 && hostileSoldier2)
            {
                var threat = hostileSoldier2;
                soldier5.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 3 && hostileSoldier3)
            {
                var threat = hostileSoldier3;
                soldier5.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 4 && hostileSoldier4)
            {
                var threat = hostileSoldier4;
                soldier5.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 5 && hostileSoldier5)
            {
                var threat = hostileSoldier5;
                soldier5.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 6 && hostileSoldier6)
            {
                var threat = hostileSoldier6;
                soldier5.GetComponent<Movement>().SetTarget(threat);
            }
            else
            {
                GameObject threat = null;
                soldier5.GetComponent<Movement>().SetTarget(threat);
            }
        }

        if (soldier6 && target6 == null)
        {
            var random = Random.Range(1, 6);
            if (random == 1 && hostileSoldier1)
            {
                var threat = hostileSoldier1;
                soldier6.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 2 && hostileSoldier2)
            {
                var threat = hostileSoldier2;
                soldier6.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 3 && hostileSoldier3)
            {
                var threat = hostileSoldier3;
                soldier6.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 4 && hostileSoldier4)
            {
                var threat = hostileSoldier4;
                soldier6.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 5 && hostileSoldier5)
            {
                var threat = hostileSoldier5;
                soldier6.GetComponent<Movement>().SetTarget(threat);
            }
            else if (random == 6 && hostileSoldier6)
            {
                var threat = hostileSoldier6;
                soldier6.GetComponent<Movement>().SetTarget(threat);
            }
            else
            {
                GameObject threat = null;
                soldier6.GetComponent<Movement>().SetTarget(threat);
            }
        }
    }

    /*public void Unit1LostTarget()
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


    }*/
}
