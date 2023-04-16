using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jefeScript : MonoBehaviour
{
    public GameObject enemyBullet;

    Vector3 playerPos;

    float speed = 20f;

    int counter = 3;

    float range = 10f;

    Vector3 rangeDetector;

    float ratio = 0;

    int ratioInt;

    public float enemyLife3 = 10f;

    bool enemyHit = false;

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

        //Matar al jefe

        if (enemyHit)
        {
            enemyLife3--;
            enemyHit = false;
        }

        if (enemyLife3 <= 0)
        {
            Destroy(gameObject);
        }

        //Disparos del jefe

        rangeDetector = (transform.position - playerPos);
        ratioInt = Mathf.RoundToInt(ratio);

        if (rangeDetector.magnitude < range)
        {
            if (ratio > .18f && ratio < .22f)
            {
                while (counter > 0)
                {
                    var instance = Instantiate(enemyBullet, transform.position, Quaternion.identity);
                    instance.GetComponent<Rigidbody2D>().velocity = new Vector2((playerPos.x - transform.position.x) * speed, (playerPos.y - transform.position.y) * speed).normalized * speed;
                    
                    counter--;
                }
            }
            else if (ratio > .38f && ratio < .42f)
            {
                while (counter > 0)
                {
                    var instance = Instantiate(enemyBullet, transform.position, Quaternion.identity);
                    instance.GetComponent<Rigidbody2D>().velocity = new Vector2((playerPos.x - transform.position.x) * speed, (playerPos.y - transform.position.y) * speed).normalized * speed;

                    counter--;

                }
            }
            else if (ratio > .88f && ratio < .92f)
            {
                while (counter > 0)
                {
                    var instance = Instantiate(enemyBullet, transform.position, Quaternion.identity);
                    instance.GetComponent<Rigidbody2D>().velocity = new Vector2((playerPos.x - transform.position.x) * speed, (playerPos.y - transform.position.y) * speed).normalized * speed;
                    counter--;
                }
            }
            else if (ratio > .88f + .20f && ratio < .92f + 20f)
            {
                while (counter > 0)
                {
                    var instance = Instantiate(enemyBullet, transform.position, Quaternion.identity);
                    instance.GetComponent<Rigidbody2D>().velocity = new Vector2((playerPos.x - transform.position.x) * speed, (playerPos.y - transform.position.y) * speed).normalized * speed;
                    counter--;
                }
            }
            else
            {
                counter = 1;
            }
            ratio += (Time.deltaTime * 1.4f);

            if (ratio > 2f)
            {
                ratio = 0;
            }
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
