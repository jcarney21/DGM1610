using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damageToTake;
    public int time;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyBullet());
        //print("Bullet Spawned");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var hit = other.gameObject;
            var enemyHealth = hit.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                EnemyHealth.TakeDamage(damageToTake);
                Debug.Log("Ouch, you hit me!");
                Destroy(gameObject);

            } 

          

        }

        else if (other.gameObject.CompareTag("Ranged Enemy"))
        {
            var hit = other.gameObject;
            var enemyHealth = hit.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                EnemyHealth.TakeDamage(damageToTake);
                Debug.Log("Ouch, you hit me!");
                Destroy(gameObject);

            }

        }


    }

    /*public int Calc(int num1, int num2)
    {
        int total;

        total = num1 + num2;

        return total;

    }*/

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);


    }
}
