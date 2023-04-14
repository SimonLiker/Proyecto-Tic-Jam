using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingSystem : MonoBehaviour
{
    public GameObject bullet;

    int counter = 1;

    float speed = 20f;

    public int life = 3;

    public bool isShooted = false;

    Vector3 mousePos;

    public GameObject pantallaMuerte;

    public GameObject textMuerte;

    public GameObject botonMenu;

    float bulletRatio = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletRatio < 1f)
        {
            bulletRatio += Time.deltaTime;
        }

        Debug.Log(bulletRatio);

        //Si es disparado

        if (isShooted)
        {
            StartCoroutine(colorChange());
        }

        //muerte
        if (life <= 0)
        {
            Destroy(gameObject);

            textMuerte.SetActive(true);
            pantallaMuerte.SetActive(true);
            botonMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        //hacer que dispare hacia la posición del mouse
        if (Input.GetMouseButton(0) && bulletRatio < 1.02f && bulletRatio > .98f)
        {
            while (counter > 0)
            {
                mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                var instance = Instantiate(bullet, transform.position, transform.rotation);
                instance.GetComponent<Rigidbody2D>().velocity = new Vector2 ((mousePos.x - transform.position.x) * speed, (mousePos.y - transform.position.y)* speed).normalized * speed;
                Debug.Log(mousePos.x);
                Debug.Log(mousePos.y);
                bulletRatio = 0;
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
