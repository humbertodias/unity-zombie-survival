using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ControlaCamera : MonoBehaviour
{
    public GameObject Jogador;
    private Vector3 distanciaCompensar;

    void Start()
    {
        distanciaCompensar = transform.position - Jogador.transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position = Jogador.transform.position + distanciaCompensar;
    }
}
