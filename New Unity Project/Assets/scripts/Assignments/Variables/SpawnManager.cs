using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] mediumPrefabs;
    public GameObject[] hardPrefabs;
    public int enemyIndex;
    public int mediumIndex;
    public int hardIndex;
    public float autospawner;
    public int spawnNumber;
    public int wave;

    // Start is called before the first frame update
    void Start()
    {
        autospawner = 16;
    }

    // Update is called once per frame
    void Update()
    {
        autospawner += Time.deltaTime;

        int spawnNumber = Random.Range(1, 10);
        
        //int enemyIndex = Random.Range(0, enemyPrefabs.Length)
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        int mediumIndex = Random.Range(0, mediumPrefabs.Length);
        int hardIndex = Random.Range(0, hardPrefabs.Length);
        if (autospawner > 20f)
        {
            wave = wave + 1;

            if (wave > 0)
            {
                Instantiate(enemyPrefabs[enemyIndex], new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50)), enemyPrefabs[enemyIndex].transform.rotation);
                


            }
            else if (wave > 5)
            {
                Instantiate(mediumPrefabs[mediumIndex], new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50)), enemyPrefabs[enemyIndex].transform.rotation);
                

            }
            else if (wave > 10)
            {
                Instantiate(hardPrefabs[hardIndex], new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50)), enemyPrefabs[enemyIndex].transform.rotation);
                


            }
        }
        if (autospawner > 20.1f)
        {
            autospawner = 0;


        }
        
    }
}
