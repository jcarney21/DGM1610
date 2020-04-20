using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : MonoBehaviour
{
    //wander
    public float wanderRadius;
    public float wanderTimer;

    public Transform target;
    private NavMeshAgent agent;
    private float timer;

    public float speed;
    public int damage;
    // Detection
    public float alertDist;
    public float attackDist;
    private float distance;

    private Vector3 direction;
    
    // use this for initialation
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent> ();
        timer = wanderTimer;


    }

    // Start is called before the first frame update
    void Start()
    {
        distance = Vector3.Distance(target.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
        distance = Vector3.Distance(target.position, transform.position);
        
        //Alert
        if (distance < alertDist && distance > attackDist)
        {
            print("Enemy sees target");
            speed = 1;
            transform.LookAt(target);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);



        }

        //Follow
        else if (distance <= alertDist)
        {
            print("Enemy sees player");
            direction = target.position - transform.position;
            direction.y = 0;
            speed = 10;
            transform.LookAt(target);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (distance < attackDist)
            {
                print("Enemy is attacking");
                var health = target.gameObject.GetComponent<PlayerHealth>();

                if (health != null)
                {
                    health.TakeDamage(damage);

                }



            }

        }

        //Wander
        else if (distance > alertDist)
        {
            timer += Time.deltaTime;
            if (timer >= wanderTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;


            }


        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;



    }
}
