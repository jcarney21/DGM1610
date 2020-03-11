using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public float countdown;
    public float timedFuse;
    public bool isLive;

    public float scattermin;
    public float scattermax;

    public int shrapnelCount;

    private Rigidbody rb;

    public GameObject shrapnel;
    public GameObject deadlyShrapnel;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * 1000 * Time.deltaTime * 20);
        rb.AddForce(Vector3.up * 1000 * Time.deltaTime * 10);
        countdown = timedFuse;
        isLive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLive)
        {
            countdown -= Time.deltaTime;


        }

        if (countdown <= 0)
        {
            for (int i = 0; i < shrapnelCount; i++)
            {
                Instantiate(shrapnel, transform.position, transform.rotation * Quaternion.Euler(Random.Range(scattermin, scattermax), Random.Range(scattermin, scattermax), 0));
                Instantiate(deadlyShrapnel, transform.position, transform.rotation * Quaternion.Euler(Random.Range(scattermin, scattermax), Random.Range(scattermin, scattermax), 0));


            }
            Destroy(gameObject);

        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Physics.IgnoreCollision(other.collider, gameObject.GetComponent<Collider>());


        }
        else if (other.gameObject.CompareTag("Weapon"))
        {
            Physics.IgnoreCollision(other.collider, gameObject.GetComponent<Collider>());


        }
        else
        {
            isLive = true;


        }
    }
}
