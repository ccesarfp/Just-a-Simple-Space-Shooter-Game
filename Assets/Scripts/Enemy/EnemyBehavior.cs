using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    //Atribui variáveis de velocidade e distância
    public float moveSpeed = 2f;
    public float minDistance = 10f;
    bool playerDetected = false;

    //Atribui objeto do jogador
    private GameObject player;

    void Start()
    {
        //Encontra jogador
        player = GameObject.FindWithTag("Player");

    }

    void Update()
    {
        //Vector3 direction = (playerDirection.position - transform.position).normalized;

        //Verifica colisão com jogador e altera se foi encontrado ou não
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, minDistance);

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                playerDetected = true;
                break;
            }
        }

        //Realiza movimentação e rotação do inimigo
        if (playerDetected)
        {
            Vector3 playerDirection = (player.transform.position - transform.position).normalized;
            Vector3 targetPosition = player.transform.position - (playerDirection * minDistance);

            // Movimenta o inimigo em direção ao jogador
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Gira o inimigo na direção do jogador
            Quaternion targetRotation = Quaternion.LookRotation(playerDirection, Vector3.down);

            // Criar uma nova Quaternion que mantém a rotação atual em torno do eixo X e aplica a rotação desejada em torno dos eixos Y e Z
            Quaternion newRotation = Quaternion.Euler(-90f, targetRotation.eulerAngles.y, targetRotation.eulerAngles.z);



            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, 360 * Time.deltaTime);
        }
    }


    public bool getDetectPlayer()
    {
        return playerDetected;
    }

}