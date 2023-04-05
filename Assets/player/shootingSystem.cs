using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingSystem : MonoBehaviour
{
    public GameObject bullet;
    
    Vector2 mousePos;

    int counter = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray bulletTrajectory;

        if (Input.GetMouseButton(0))
        {
            while (counter == 1)
            {
                mousePos = Input.mousePosition;
                Instantiate(bullet, transform.position, Quaternion.identity);
                bulletTrajectory = new Ray(transform.position, mousePos);
                counter--;
            }

        }
        else
        {
            counter = 1;
        }
        bullet.transform.Translate(3f, 2f, 0f);
    }
}
