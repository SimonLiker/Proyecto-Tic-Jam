using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timeCounter : MonoBehaviour
{
    public TextMeshProUGUI timerAlive;
    float time = 0;

    float minutes = 0;
    float seconds = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }
      
    // Update is called once per frame
    void Update()
    {

        //Haciendo que el float del tiempo se vaya sumando y que su int sea aproximadamente igual

        time += Time.deltaTime;

        //Mostrar el tiempo en el texto

        displayTime(time);

    }

    void displayTime(float timeToDisplay)
    {
        minutes = Mathf.FloorToInt(timeToDisplay / 60);
        seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerAlive.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
