using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingSystem : MonoBehaviour
{
    public GameObject bullet;

    int counter = 1;

    float speed = 10f;

    public int life = 3;

    public bool isShooted = false;

    Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Si es disparado

        if (isShooted)
        {
            StartCoroutine(colorChange());
        }

        //muerte
        if (life <= 0)
        {
            Destroy(gameObject);
            Time.timeScale = 0f;
        }

        //hacer que dispare hacia la posición del mouse
        if (Input.GetMouseButton(0))
        {
            while (counter == 1)
            {
                mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                var instance = Instantiate(bullet, transform.position, Quaternion.identity);
                instance.GetComponent<Rigidbody2D>().velocity = new Vector2 ((mousePos.x - transform.position.x) * speed, (mousePos.y - transform.position.y)* speed).normalized * speed;
                Debug.Log(mousePos.x);
                Debug.Log(mousePos.y);
                counter--;
            }

        }
        else
        {
            counter = 1;
        }

        IEnumerator colorChange()
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);

            yield return new WaitForSeconds(.2f);

            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }
}
