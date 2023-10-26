using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerScript : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    public Vector3 center;
    public Vector3 size;

    public int spawnTimes;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", 10, 2);
    }


    void Update()
    {
        if (spawnTimes > 0)
        {
            SpawnObstacle();
        }
    }

    public void SpawnObstacle()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), 10, Random.Range(-size.z / 2, size.z / 2));

        int randomizerInt = Random.Range(0, 5);
        if (randomizerInt == 0)
        {
            Instantiate(obstaclePrefabs[0], pos, Quaternion.identity);
        }
        if (randomizerInt == 1)
        {
            Instantiate(obstaclePrefabs[1], pos, Quaternion.identity);
        }
        if (randomizerInt == 2)
        {
            Instantiate(obstaclePrefabs[2], pos, Quaternion.identity);
        }
        if (randomizerInt == 3)
        {
            Instantiate(obstaclePrefabs[3], pos, Quaternion.identity);
        }
        if (randomizerInt == 4)
        {
            Instantiate(obstaclePrefabs[4], pos, Quaternion.identity);
        }        

        spawnTimes -= 1;
    }    
}
