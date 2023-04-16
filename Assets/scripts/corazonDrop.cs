using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corazonDrop : MonoBehaviour
{
    shootingSystem shootingShortcut;
    corazonMerger corazonShortcut;
    // Start is called before the first frame update
    void Start()
    {
        shootingShortcut = FindObjectOfType<shootingSystem>();
        corazonShortcut = FindObjectOfType<corazonMerger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            shootingShortcut.life += 1;
            corazonShortcut.añadirCorazon();
            Destroy(gameObject);

        }
    }
}
