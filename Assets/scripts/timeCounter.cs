using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timeCounter : MonoBehaviour
{
    public TextMeshProUGUI timerAlive;
    float time = 0;
    int timeInt = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }
      
    // Update is called once per frame
    void Update()
    {

        //Haciendo que el float del tiempo se vaya sumando y que su int sea aproximadamente igual

        time += Time.deltaTime;
        timeInt = Mathf.RoundToInt(time);

        //Mostrar el tiempo en el texto

        timerAlive.text = timeInt.ToString();
    }
}
