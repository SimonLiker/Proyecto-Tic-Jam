using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    enemy1Script basicEnemyShortcut;
    enemy2Script strongerEnemyShortcut;
    // Start is called before the first frame update
    void Start()
    {
        basicEnemyShortcut = FindObjectOfType<enemy1Script>();
        strongerEnemyShortcut = FindObjectOfType<enemy2Script>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "basicEnemy")
        {
            Debug.Log("Enemigo impactado");
            basicEnemyShortcut.enemyLife--;
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "enemigoMasFuerte")
        {
            strongerEnemyShortcut.enemyLife2--;
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "obstaculo")
        {
            Destroy(gameObject);
        }
    }
}
