using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
public float Velocidade = 20;
    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position +
                                               transform.forward * (Velocidade * Time.deltaTime));
    }

    void OnTriggerEnter(Collider objetoDeColisao)
    {
        if (objetoDeColisao.CompareTag("Inimigo"))
        {
            Destroy(objetoDeColisao.gameObject);
        }
        Destroy(gameObject);
    }
}
