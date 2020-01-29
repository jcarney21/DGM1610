using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public float turnSpeed;
    public float verticalInput;
    public float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);//Equal 2 (0, 0, .1f)
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * horizontalInput);
        // x, y, z
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
