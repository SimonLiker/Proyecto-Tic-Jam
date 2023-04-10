using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingSystem : MonoBehaviour
{
    public GameObject bullet;

    int counter = 1;

    float speed = 150f;

    public int life = 3;

    Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            while (counter == 1)
            {
                mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
                var instance = Instantiate(bullet, transform.position, Quaternion.identity);
                instance.GetComponent<Rigidbody2D>().AddForce((mousePos - transform.position) * speed);
                Debug.Log(mousePos.x);
                Debug.Log(mousePos.y);
                counter--;
            }

        }
        else
        {
            counter = 1;
        }
    }
}
