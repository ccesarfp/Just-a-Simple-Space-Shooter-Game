using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    //Atribui variáveis de velocidade e distância
    public float moveSpeed = 2f;
    public float minDistance = 10f;

    //Atribui objeto do jogador
    private GameObject player;

    void Start()
    {
        //Encontra jogador
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        //Verifica colisão com jogador e altera se foi encontrado ou não
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, minDistance);
        bool playerDetected = false;

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                playerDetected = true;
                break;
            }
        }

        //Realiza movimentação do inimigo
        if (playerDetected)
        {
            Vector3 playerDirection = (player.transform.position - transform.position).normalized;
            Vector3 targetPosition = player.transform.position - (playerDirection * minDistance);

            transform.LookAt(player.transform);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}