using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    float time = 0;
    int timeInt = 0;

    public GameObject basicEnemy;

    int randSpawnPoint;

    int counter = 1;

    int cantToSpawn = 1;

    int counter2 = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeInt = Mathf.RoundToInt(time);

        if (timeInt > 0 && timeInt % 4 == 0)
        {
            while (counter > 0)
            {
                randSpawnPoint = Random.Range(0, spawnPoints.Length);

                Instantiate(basicEnemy, spawnPoints[randSpawnPoint].transform.position, Quaternion.identity);

                counter--;
            }
        }
        else
        {
            counter = cantToSpawn; ;
        }

        if (timeInt % 15 == 0 && timeInt > 0)
        {
            while (counter2 > 0)
            {
                cantToSpawn++;
                counter2--;
            }
        }
        else
        {
            counter2 = 1; 
        }
    }
}
