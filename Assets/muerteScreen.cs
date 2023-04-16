using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class muerteScreen : MonoBehaviour
{
    timeCounter timerShortcut;
    public TextMeshProUGUI muerteText;
    // Start is called before the first frame update
    void Start()
    {
        timerShortcut = FindObjectOfType<timeCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        muerteText.text = ("Has sobrevivido: " + timerShortcut.timerAlive.text + " min.");
    }
}
