using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1Script : MonoBehaviour
{
    public GameObject enemyBullet;

    Vector3 playerPos;

    float speed = 30f;

    int counter = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Debug.Log(playerPos);

        RaycastHit2D playerDetection = Physics2D.Raycast(gameObject.transform.position, new Vector3(Mathf.Cos(gameObject.transform.rotation.x), Mathf.Sin(gameObject.transform.rotation.y)), 5f);
        Debug.DrawRay(gameObject.transform.position, new Vector3(Mathf.Cos(gameObject.transform.rotation.x), Mathf.Sin(gameObject.transform.rotation.y))*5f, Color.red);

        if (playerDetection.collider.tag == "Player")
        {
            Debug.Log("Hola");
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
    }
}
