using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementFix : MonoBehaviour
{

    shootingSystem shootingShortcut;

    float speed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        shootingShortcut = FindObjectOfType<shootingSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //Player rotation

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //Player movement
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        //Slowing time down

        if (Input.GetKey(KeyCode.T) && shootingShortcut.life > 0)
        {
            StartCoroutine(timeSlower());
        }
    } 

    IEnumerator timeSlower()
    {
        Time.timeScale = 0.5f;
        speed = 16f;
        yield return new WaitForSeconds(5f);
        Time.timeScale = 1f;
        speed = 2f;
    }
}
