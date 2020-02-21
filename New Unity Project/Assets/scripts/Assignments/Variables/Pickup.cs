using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public int pointsToAdd;
    public float timeToDie;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, timeToDie);


    }

    void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.CompareTag("Player"))
        {
            ScoreManager.AddPoints(pointsToAdd);
            Destroy(gameObject);

        }


    }
}
