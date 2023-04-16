using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2Script : MonoBehaviour
{
    public GameObject enemyBullet;

    Vector3 playerPos;

    float speed = 10f;

    int counter = 3;

    float range = 8f;

    Vector3 rangeDetector;

    float ratio = 0;

    int ratioInt;

    public float enemyLife2 = 2;

    bool enemyHit = false;

    public GameObject[] strongerEnemy;

    GameObject player;

    float bulletRatio = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //Rotación respecto al jugador

        Vector3 playerPos = player.transform.position;
        Vector3 direction = playerPos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        strongerEnemy = GameObject.FindGameObjectsWithTag("enemigoMasFuerte");

        //Matar al enemigo
        for (int i = 0; i < strongerEnemy.Length; i++)
        {
            if (strongerEnemy[i].GetComponent<enemy2Script>().enemyHit)
            {
                strongerEnemy[i].GetComponent<enemy2Script>().enemyLife2 --;
                strongerEnemy[i].GetComponent<enemy2Script>().enemyHit = false;
            }

            if (strongerEnemy[i].GetComponent<enemy2Script>().enemyLife2 <= 0)
            {
                Destroy(strongerEnemy[i]);
            }
        }

        //Hacer que dispare

        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        rangeDetector = (transform.position - playerPos);
        ratioInt = Mathf.RoundToInt(ratio);

        if (rangeDetector.magnitude < range)
        {
            if (ratio > .18f && ratio < .22f)
            {
                while (counter > 0)
                {
                    soundManager.PlaySound("disparoEnemigo");
                    var instance = Instantiate(enemyBullet, gameObject.transform.position, Quaternion.identity);
                    instance.GetComponent<Rigidbody2D>().velocity = new Vector2((playerPos.x - transform.position.x) * speed, (playerPos.y - transform.position.y) * speed).normalized * speed;
                    counter--;
                }
            }
            else if (ratio > .38f && ratio < .42f)
            {
                    while (counter > 0)
                    {
                        var instance = Instantiate(enemyBullet, gameObject.transform.position, Quaternion.identity);
                        instance.GetComponent<Rigidbody2D>().velocity = new Vector2((playerPos.x - transform.position.x) * speed, (playerPos.y - transform.position.y) * speed).normalized * speed;
                        counter--;
                    }
            }
            else if (ratio > .58f && ratio < .62f)
            {
                while (counter > 0)
                {
                    var instance = Instantiate(enemyBullet, gameObject.transform.position, Quaternion.identity);
                    instance.GetComponent<Rigidbody2D>().velocity = new Vector2((playerPos.x - transform.position.x) * speed, (playerPos.y - transform.position.y) * speed).normalized * speed;
                    counter--;
                }
            }
            else
            {
                counter = 1;
            }

            if (ratio > 1.5f)
            {
                ratio = 0;
            }
            ratio += (Time.deltaTime * 1.4f);

        }
        else
        {
            ratio = 0;
        }
 
    
}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerBullet")
        {
            enemyHit = true;
        }
    }
}
