using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public int enemyIndex;
    public float autospawner;
    public int spawnNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        autospawner += Time.deltaTime;

        int spawnNumber = Random.Range(1, 10);
        
        //int enemyIndex = Random.Range(0, enemyPrefabs.Length)
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        if (autospawner > 6f)
        {
            Instantiate(enemyPrefabs[enemyIndex], new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50)), enemyPrefabs[enemyIndex].transform.rotation);
            autospawner = 0;
        }
        
    }
}
