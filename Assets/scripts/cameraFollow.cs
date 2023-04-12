using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f; // que tan rapido la camara se mueve hasta el jugador
    public float yOffset = 1f;
    public Transform target; // nos da la pocision del jugador

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f); // nos da la pocision del jugador en "x" e "y" pero "z" se queda en -10 porque sino la camara no puede mostrar nada
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}


