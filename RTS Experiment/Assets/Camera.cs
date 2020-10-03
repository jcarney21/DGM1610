using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private float maxZoom = 2;
    private float minZoom = 15;

    public float zoom;

    public float scrollwheel;

    public float horizontalAxis;
    public float verticalAxis;

    public int sensitivity;
    // Start is called before the first frame update
    void Start()
    {
        zoom = 4;
    }

    // Update is called once per frame
    void Update()
    {
        scrollwheel = Input.GetAxis("Mouse ScrollWheel");
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalAxis * 1/(10-sensitivity), Space.World);

        transform.Translate(Vector3.forward * verticalAxis * 1/(10-sensitivity), Space.World);

        if (zoom >= maxZoom && scrollwheel > 0)
        {
            transform.Translate (0, 0, 1 * scrollwheel);
            zoom = zoom - scrollwheel;


        }
        else if (zoom <= minZoom && scrollwheel < 0)
        {
            transform.Translate(0, 0, 1 * scrollwheel);
            zoom = zoom - scrollwheel;

        }

    }
}
