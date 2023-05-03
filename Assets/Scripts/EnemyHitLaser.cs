using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitLaser : MonoBehaviour
{


    void Start()
    {

    }

    void Update()
    {

    }

    /**
     * @name OnCollisionEnter()
     * @params:
     *  Collision collision - informação de colisão
     * Configura evento de colisão do laser
     */
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}

