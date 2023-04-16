using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovementFix : MonoBehaviour
{

    shootingSystem shootingShortcut;
    float energySliderValue = 0;
    float speed = 8f;

    int counter = 1;
    int counter2 = 1;

    public GameObject pantallaSlowed;

    bool timeSlowed = false;
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

        if (Input.GetKeyDown(KeyCode.Space) && shootingShortcut.life > 0 && timeSlowed == false)
        {
            while (counter > 0)
            {
                StartCoroutine(timeSlower());
                counter--;
            }
            
            energySliderValue = 5f;
            if (energySliderValue > 0)
            {
                energySliderValue -= Time.deltaTime;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && shootingShortcut.life > 0 && timeSlowed)
        {
            StopCoroutine(timeSlower());
            timeSlowed = false;
            pantallaSlowed.SetActive(false);
            speed = 8f;
            Time.timeScale = 1f;
            Debug.Log("Coroutine cancelada");
        }
        else
        {
            counter = 1;
            counter2++;
        }
    } 

    //Coroutine para hacer el tiempo más lento
    IEnumerator timeSlower()
    {
        Debug.Log("Timescale = 0.5");
        pantallaSlowed.SetActive(true);
        Time.timeScale = 0.5f;
        speed = 16f;

        timeSlowed = true;

        yield return new WaitForSeconds(2.5f);
        Debug.Log("Timescale = 1");
        timeSlowed = false;
        Time.timeScale = 1f;
        pantallaSlowed.SetActive(false);
        speed = 8f;
        while (counter2 > 0)
        {
            //shootingShortcut.life--;
            counter2--;
        }
    }
}
