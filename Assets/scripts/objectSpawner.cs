using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    float time = 0;
    int timeInt = 0;
    public GameObject newWeapon;
    int randSpawnPoint;
    int counter = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeInt = Mathf.RoundToInt(time);

        if (timeInt == 30)
        {
            while (counter > 0)
            {
                randSpawnPoint = Random.Range(0, spawnPoints.Length);

                Instantiate(newWeapon, spawnPoints[randSpawnPoint].transform.position, Quaternion.identity);

                counter--;
            }
        }
        else
        {
            counter = 1;
        }
    }
}
