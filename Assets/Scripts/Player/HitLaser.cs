using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitLaser : MonoBehaviour
{
    private AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
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
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            sound.Play();
            Destroy(gameObject);
        }
    }
}
