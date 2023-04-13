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

    public GameObject strongerEnemy;

    int counter3 = 1;

    int randSpawnPoint2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeInt = Mathf.RoundToInt(time);

        //primer enemigo

        if (timeInt > 0 && timeInt % 4 == 0)
        {
            while (counter > 0)
            {
                randSpawnPoint = Random.Range(0, spawnPoints.Length);

                var Instance = Instantiate(basicEnemy, spawnPoints[randSpawnPoint].transform.position, Quaternion.identity);

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

        //segundo enemigo

        if (timeInt > 0 && timeInt % 3 == 0)
        {
            while (counter3 > 0)
            {
                Debug.Log("Enemigo fuerte iniciado");

                randSpawnPoint2 = Random.Range(0, spawnPoints.Length);

                Instantiate(strongerEnemy, spawnPoints[randSpawnPoint2].transform.position, Quaternion.identity);

                counter3--;
            }
            
        }
        else
        {
            counter3 = 1;
        }
    }
}
