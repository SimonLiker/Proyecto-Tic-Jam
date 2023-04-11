using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    enemy1Script basicEnemyShortcut;
    // Start is called before the first frame update
    void Start()
    {
        basicEnemyShortcut = FindObjectOfType<enemy1Script>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "basicEnemy")
        {
            basicEnemyShortcut.enemyLife--;
            Destroy(gameObject);
        }
    }
}
