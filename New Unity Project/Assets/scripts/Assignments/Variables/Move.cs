using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float verticalInput;
    public float horizontalInput;
    public int ammoMag;
    public static int ammoTotal;
    

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        ammoMag = 15;
        ammoTotal = 15;
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);//Equal 2 (0, 0, .1f)
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * horizontalInput);
        // x, y, z

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ammoMag >= 1)
            {
                Instantiate(projectilePrefab, transform.position, transform.rotation); //projectilePrefab.transform.rotation
                 ammoMag = ammoMag - 1;
                print("ammunition: " + ammoMag);


            }

            else
            {
                print("No Ammo");

            }
            
        }

        if (ammoMag < 1)
        {
            if (ammoTotal >= 1)
            {
                ammoMag = 15;
                ammoTotal = ammoTotal - 15;
                print("ammunition: " + ammoMag);
                print("Total Ammo: " + ammoTotal);


            }
         

        }
        //GetKeyDown is a single input, Get key (or getdown, because I don't remember) continues each time it fires

        
    }

    public static void AddAmmo(int ammoToAdd)
    {
        ammoTotal = ammoTotal + ammoToAdd;


    }


    // Detect collision with another object
    /*void OnCollisionEnter(Collision other){
        

        if (other.gameObject.CompareTag("Ground"))//Primary
        {
            Debug.Log("Colliding with Floor");
        }
        else if(other.gameObject.CompareTag("Obstacle"))//Secondary
        {
            Debug.Log("Colliding with an Obstacle");
        }
        else//Tertiary or default
        {
            Debug.Log("...");
        
        }
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("Triggered");
    }
    */
}
