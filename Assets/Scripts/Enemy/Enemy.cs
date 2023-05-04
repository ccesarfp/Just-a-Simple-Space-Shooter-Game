using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy; //identifica o inimigo
    public int enemyHP = 3; //Hp do inimigo
    public Player player;
    
    void Start()
    {
        
    }

    void Update()
    {
        if(enemyHP <= 0) //verifica se o Hp do inimigo estiver igual ou abaixo de 0
        {
            player.aumentarPoints(10f);
            enemyHP = 3; //Reseta o Hp do inimigo para esse if n�o ficar rodando infinitamente
            transform.position = new Vector3(2.68f, 2, -2); //Reseta a posi��o do inimigo pra respawnar ele no lugar certo
            Instantiate(enemy, transform.position, transform.rotation); //Respawna o inimgo
            Destroy(enemy.gameObject);//Destroi o inimgo que foi morto
            
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Laser_P"))
        {
            enemyHP = enemyHP - 1; //Ele perde 1 de HP
        }
    }
}
