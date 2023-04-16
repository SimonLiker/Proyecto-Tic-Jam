using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1Script : MonoBehaviour
{
    public GameObject enemyBullet;

    Vector3 playerPos;

    float speed = 10f;

    int counter = 1;

    float range = 8f;

    Vector3 rangeDetector;

    float ratio = 0;

    int ratioInt;

    public float enemyLife = 1;

    public GameObject[] basicEnemy;

    bool isShooted = false;

    GameObject player;
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

        basicEnemy = GameObject.FindGameObjectsWithTag("basicEnemy");
        //Matar al enemigo

        for (int i = 0; i < basicEnemy.Length; i++)
        { 
            if (basicEnemy[i].GetComponent<enemy1Script>().isShooted)
            {
                basicEnemy[i].GetComponent<enemy1Script>().enemyLife--;
                basicEnemy[i].GetComponent<lootBag>().InstantiateLoot(basicEnemy[i].transform.position);
                basicEnemy[i].GetComponent<enemy1Script>().isShooted = false;
            }
            if (basicEnemy[i].GetComponent<enemy1Script>().enemyLife <= 0)
            {
                Destroy(basicEnemy[i]);

            }
          
        }

        //Hacer que dispare

        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        rangeDetector = (transform.position - playerPos);
        ratioInt = Mathf.RoundToInt(ratio);

        if (rangeDetector.magnitude < range)
        {
         if (ratioInt % 2 == 0)
            {
                while (counter > 0)
                {
                    soundManager.PlaySound("disparoEnemigo2");
                    var instance = Instantiate(enemyBullet, gameObject.transform.position, Quaternion.identity);
                    instance.GetComponent<Rigidbody2D>().velocity = new Vector2((playerPos.x - transform.position.x) * speed, (playerPos.y - transform.position.y) * speed).normalized * speed;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerBullet")
        {
            isShooted = true;
        }
    }
}
