using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] mediumPrefabs;
    public GameObject[] hardPrefabs;
    public GameObject[] powerupPrefabs;
    public GameObject[] terrainPrefabs;
    public int enemyIndex;
    public int mediumIndex;
    public int hardIndex;
    public int powerupIndex;
    public int terrainIndex;
    public float autospawner;
    public float terrainGenerator;
    public int spawnNumber;
    public int wave;

    // Start is called before the first frame update
    void Start()
    {
        autospawner = 16;
        terrainGenerator = 0;
    }

    // Update is called once per frame
    void Update()
    {
        autospawner += Time.deltaTime;

        if (terrainGenerator < 4)
        {
            terrainGenerator += Time.deltaTime;

        }
        

        int spawnNumber = Random.Range(1, 10);
        
        //int enemyIndex = Random.Range(0, enemyPrefabs.Length)
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        int mediumIndex = Random.Range(0, mediumPrefabs.Length);
        int hardIndex = Random.Range(0, hardPrefabs.Length);
        int powerupIndex = Random.Range(0, powerupPrefabs.Length);
        int terrainIndex = Random.Range(0, terrainPrefabs.Length);

        //All of the waves and autospawner part
        if (autospawner > 20f)
        {
            
            Instantiate(powerupPrefabs[powerupIndex], new Vector3(Random.Range(-70, 70), 0, Random.Range(-70, 70)), powerupPrefabs[powerupIndex].transform.rotation);

            if (wave < 0)
            {



            }
            else if (wave < 6)
            {
                Instantiate(enemyPrefabs[enemyIndex], new Vector3(Random.Range(-70, 70), 0, Random.Range(-70, 70)), enemyPrefabs[enemyIndex].transform.rotation);
                


            }
            else if (wave < 11)
            {
                Instantiate(mediumPrefabs[mediumIndex], new Vector3(Random.Range(-70, 70), 0, Random.Range(-70, 70)), enemyPrefabs[enemyIndex].transform.rotation);
                

            }
            else if (wave < 31)
            {
                Instantiate(hardPrefabs[hardIndex], new Vector3(Random.Range(-70, 70), 0, Random.Range(-70, 70)), enemyPrefabs[enemyIndex].transform.rotation);
                


            }
        }
        if (autospawner > 20.2f)
        {
            autospawner = 0;
            wave = wave + 1;

        }

        //Terrain Generator
        if (terrainGenerator < 4)
        {
            Instantiate(terrainPrefabs[terrainIndex], new Vector3(Random.Range(-80, 80), 0, Random.Range(-80, 80)), Quaternion.Euler(new Vector3(0, Random.Range(0, 270), 0)));


        }


        
    }
}
