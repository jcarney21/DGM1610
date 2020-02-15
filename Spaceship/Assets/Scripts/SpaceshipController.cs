using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{

    public float speed;
    public float turnSpeed;
    public float spinSpeed;
    public float jumpSpeed;
    public float forwardInput;
    public float spinInput;
    public float turningInputX;
    public float turningInputY;
    public float jumpInput;
    public float health;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        spinInput = Input.GetAxis("Horizontal");
        turningInputX = Input.GetAxis("Mouse X");
        jumpInput = Input.GetAxis("Jump");
        turningInputY = Input.GetAxis("Mouse Y");

        transform.Translate(Vector3.back * (speed/10f) * Time.deltaTime * (forwardInput + 2f));//Equal 2 (0, 0, .1f)
        transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime * spinInput);
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * turningInputX);
        transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime * jumpInput);
        transform.Rotate(Vector3.right * turnSpeed * Time.deltaTime * turningInputY);
        // x, y, z

        if (1 > health)
        {

            speed = 0f;
            turnSpeed = 0f;
            spinSpeed = 0f;
            jumpSpeed = 0f;
            Destroy(gameObject);
           

            print("Game Over");

        }
    }

    // Detect Collision with another object
    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Ground"))
        {

            health = health - (20 * (forwardInput + 2f));

            print("Current HP: " + health);
        }

        else
        {

            health = health - (10 * (forwardInput + 2f));

            print("Current HP: " + health);

        }
    }
}
