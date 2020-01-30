using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour
{

    public float speed;
    public float turnSpeed;
    public float verticalSpeed;
    public float verticalInput;
    public float horizontalInput;
    public float rightInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        rightInput = Input.GetAxis("Jump");

        transform.Translate(Vector3.back * speed * Time.deltaTime * verticalInput);//Equal 2 (0, 0, .1f)
        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * horizontalInput);
        transform.Translate(Vector3.up * verticalSpeed * Time.deltaTime * rightInput);
        // x, y, z
    }
}
