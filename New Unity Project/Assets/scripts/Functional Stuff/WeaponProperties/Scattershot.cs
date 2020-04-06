using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scattershot : MonoBehaviour
{
    public GameObject scattershotPrefabs;
    public Transform newHeading;
    public float scattermin;
    public float scattermax;

    // Start is called before the first frame update
    void Start()
    {
        //newHeading = transform.rotation 
        Instantiate(scattershotPrefabs, transform.position, transform.rotation * Quaternion.Euler(Random.Range(scattermin, scattermax), Random.Range(scattermin, scattermax), 0));
        Instantiate(scattershotPrefabs, transform.position, transform.rotation * Quaternion.Euler(Random.Range(scattermin, scattermax), Random.Range(scattermin, scattermax), 0));
        Instantiate(scattershotPrefabs, transform.position, transform.rotation * Quaternion.Euler(Random.Range(scattermin, scattermax), Random.Range(scattermin, scattermax), 0));
        Instantiate(scattershotPrefabs, transform.position, transform.rotation * Quaternion.Euler(Random.Range(scattermin, scattermax), Random.Range(scattermin, scattermax), 0));
        Instantiate(scattershotPrefabs, transform.position, transform.rotation * Quaternion.Euler(Random.Range(scattermin, scattermax), Random.Range(scattermin, scattermax), 0));
        Instantiate(scattershotPrefabs, transform.position, transform.rotation * Quaternion.Euler(Random.Range(scattermin, scattermax), Random.Range(scattermin, scattermax), 0));
        Instantiate(scattershotPrefabs, transform.position, transform.rotation * Quaternion.Euler(Random.Range(scattermin, scattermax), Random.Range(scattermin, scattermax), 0));
        Instantiate(scattershotPrefabs, transform.position, transform.rotation * Quaternion.Euler(Random.Range(scattermin, scattermax), Random.Range(scattermin, scattermax), 0));
        Instantiate(scattershotPrefabs, transform.position, transform.rotation * Quaternion.Euler(Random.Range(scattermin, scattermax), Random.Range(scattermin, scattermax), 0));
        Instantiate(scattershotPrefabs, transform.position, transform.rotation * Quaternion.Euler(Random.Range(scattermin, scattermax), Random.Range(scattermin, scattermax), 0));
        Instantiate(scattershotPrefabs, transform.position, transform.rotation * Quaternion.Euler(Random.Range(scattermin, scattermax), Random.Range(scattermin, scattermax), 0));
        Instantiate(scattershotPrefabs, transform.position, transform.rotation * Quaternion.Euler(Random.Range(scattermin, scattermax), Random.Range(scattermin, scattermax), 0));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
