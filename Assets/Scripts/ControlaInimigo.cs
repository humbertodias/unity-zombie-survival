using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    public GameObject Jogador;
    public float Velocidade = 5;

    private Rigidbody rigidBodyInimigo;
    private Animator animatorInimigo;

    void Start()
    {
        rigidBodyInimigo = GetComponent<Rigidbody>();
        animatorInimigo = GetComponent<Animator>();
        
        Jogador = GameObject.FindWithTag("Jogador");
        int geraTipoZumbi = Random.Range(1, 28);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
    }
    
    void FixedUpdate()
    {

        Vector3 direcao = Jogador.transform.position - transform.position;
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);

        rigidBodyInimigo.MoveRotation(novaRotacao);

        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);
        if (distancia > 2.5)
        {
            rigidBodyInimigo.MovePosition(
                rigidBodyInimigo.position + 
                direcao.normalized * (Velocidade * Time.deltaTime)
            );
            animatorInimigo.SetBool("Atacando", false);
        }
        else
        {
            animatorInimigo.SetBool("Atacando", true);
        }
        
    }

    void AtacarJogador()
    {
        Time.timeScale = 0;
        Jogador.GetComponent<ControlaJogador>().TextoGameOver.SetActive(true);
        Jogador.GetComponent<ControlaJogador>().Vivo = false;
    }
}
