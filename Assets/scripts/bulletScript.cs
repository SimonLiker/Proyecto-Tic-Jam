using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    enemy1Script enemyShortcut1;
    enemy2Script enemyShortcut2;


    // Start is called before the first frame update
    void Start()
    {
        enemyShortcut1 = FindObjectOfType<enemy1Script>();
        enemyShortcut2 = FindObjectOfType<enemy2Script>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "basicEnemy")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "enemigoMasFuerte")
        {
            
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "obstaculo")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "jefe")
        {
            Destroy(gameObject);
        }
    }
}
