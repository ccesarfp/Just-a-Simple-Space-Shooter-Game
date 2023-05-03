using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitLaser : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
