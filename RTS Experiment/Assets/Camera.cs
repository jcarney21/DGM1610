using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private float maxZoom = 2;
    private float minZoom = 15;

    public float zoom;

    public float scrollwheel;
    // Start is called before the first frame update
    void Start()
    {
        zoom = 4;
    }

    // Update is called once per frame
    void Update()
    {
        scrollwheel = Input.GetAxis("Mouse ScrollWheel");
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
