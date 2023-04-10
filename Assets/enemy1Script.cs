using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1Script : MonoBehaviour
{
    public GameObject enemyBullet;

    Vector3 playerPos;

    float speed = 75f;

    int counter = 1;

    float range = 40f;

    Vector3 rangeDetector;

    float ratio = 0;

    int ratioInt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        rangeDetector = (transform.position - playerPos);
        ratioInt = Mathf.RoundToInt(ratio);

        if (rangeDetector.magnitude < range)
        {
         if (ratioInt % 2 == 0)
            {
                while (counter > 0)
                {
                    var instance = Instantiate(enemyBullet, gameObject.transform.position, Quaternion.identity);
                    instance.GetComponent<Rigidbody2D>().AddForce((playerPos - transform.position) * speed);
                    counter--;
                }
            }
            else
            {
                counter = 1;
            }
            ratio += (Time.deltaTime * 1.4f);
        }
        else
        {
            ratio = 0;
        }
    }
}
