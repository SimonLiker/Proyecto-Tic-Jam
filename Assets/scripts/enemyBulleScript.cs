using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulleScript : MonoBehaviour
{

    shootingSystem playerShortcut;
    // Start is called before the first frame update
    void Start()
    {
        playerShortcut = FindObjectOfType<shootingSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(colorDelay());
            Debug.Log("jugador impactado");
            playerShortcut.life--;
            Destroy(gameObject);

        }
        else if (collision.gameObject.tag == "obstaculo")
        {
            Destroy(gameObject);
        }
        else
        {
            playerShortcut.isShooted = false;
        }
    }
    IEnumerator colorDelay()
    {
        playerShortcut.isShooted = true;

        yield return new WaitForSeconds(Time.deltaTime);

        playerShortcut.isShooted = false;
    }
}
