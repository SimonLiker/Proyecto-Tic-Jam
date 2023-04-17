using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class corazonMerger : MonoBehaviour
{
    public GameObject corazon;
    public GameObject canvas;

    public GameObject[] corazones;
    
    float ultimoCorazonPos = -10f;

    float corazonPosY = 0;

    int counter = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        corazones = GameObject.FindGameObjectsWithTag("corazon");
    }
    
    public void quitarCorazon()
    {
        Destroy(corazones[corazones.Length - 1]);
        ultimoCorazonPos -= 55f;
    }

    public void añadirCorazon()
    {
        Debug.Log("corazonAñadido");
        var instance = Instantiate(corazon);
        instance.transform.parent = canvas.transform;
        instance.GetComponent<RectTransform>().localPosition = new Vector2(ultimoCorazonPos, corazones[1].GetComponent<RectTransform>().anchoredPosition.y);
        instance.GetComponent<RectTransform>().localScale = corazones[1].GetComponent<RectTransform>().localScale;
        ultimoCorazonPos += 55;
    }
}
