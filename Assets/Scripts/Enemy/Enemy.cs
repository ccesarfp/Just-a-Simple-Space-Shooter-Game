using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy; //identifica o inimigo
    public GameObject item; // identifica o item
    public int enemyHP = 3; //Hp do inimigo
    
    void Start()
    {
        
    }

    void Update()
    {
        if(enemyHP <= 0) //verifica se o Hp do inimigo estiver igual ou abaixo de 0
        {
          
            transform.position = new Vector3(0.15f, 2, -2.01f); //coloca o inimigo na posi��o que o item vai spawnar, j� q o spawn do item usa de parametro a posi��o do inimigo
            Instantiate(item, transform.position, transform.rotation); //spawna o item
            enemyHP = 3; //Reseta o Hp do inimigo para esse if n�o ficar rodando infinitamente
            transform.position = new Vector3(2.68f, 2, -2); //Reseta a posi��o do inimigo pra respawnar ele no lugar certo
            Instantiate(enemy, transform.position, transform.rotation); //Respawna o inimgo
            Destroy(enemy.gameObject);//Destroi o inimgo que foi morto
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Laser_P")) //Se o inimigo colidir com o tiro do player
        {
            enemyHP = enemyHP - 1; //Ele perde 1 de HP
            
        }
    }
}
