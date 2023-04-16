using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{

    public static AudioClip fireSound, enemyFireSound, enemyFireSound2, disparoBoss;

    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        fireSound = Resources.Load<AudioClip>("disparo");
        enemyFireSound = Resources.Load<AudioClip>("disparoEnemigo2");
        enemyFireSound2 = Resources.Load<AudioClip>("disparoEnemigo");
        disparoBoss = Resources.Load<AudioClip>("disparoBoss");

        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "disparo":
                audioSrc.PlayOneShot(fireSound);
                break;

             case "disparoEnemigo2":
                audioSrc.PlayOneShot(enemyFireSound);
                break;
            case "disparoEnemigo":
                audioSrc.PlayOneShot(enemyFireSound2);
                break;
            case "disparoBoss":
                audioSrc.PlayOneShot(disparoBoss);
                break;
        }
    }



}
