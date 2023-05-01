using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShot : MonoBehaviour
{
    public GameObject laser; // Prefab do projetil a ser disparado
    public float velocidadeProjetil = 10; // Velocidade do projetil
    public float intervaloDisparo = 1; // Tempo de intervalo entre os disparos
    private float tempoUltimoDisparo; // Hora do último disparo

    void Start()
    {
        //Destroy(gameObject, 3f);
    }

    void Update()
    {
        // Verifica se é hora de disparar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > tempoUltimoDisparo + intervaloDisparo)
            {
                // Dispara o projetil
                DispararProjetil();
                // Atualiza o tempo do último disparo
                tempoUltimoDisparo = Time.time;
            }
        }

    }

    private void DispararProjetil()
    {
        // Cria uma nova instância do projetil
        GameObject novoProjetil = Instantiate(laser, transform.position, transform.rotation);

        // Aplica força ao projetil na direção da nave
        Rigidbody rb = novoProjetil.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 400);
        Destroy(novoProjetil, 3f);
    }

}
