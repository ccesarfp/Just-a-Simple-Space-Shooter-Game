using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public GameObject enemyLaser; // Prefab do projetil a ser disparado
    public float velocidadeProjetil = 10; // Velocidade do projetil
    public float intervaloDisparo = 1; // Tempo de intervalo entre os disparos
    private float tempoUltimoDisparo; // Hora do último disparo

    private bool playerDetected = false;
    EnemyBehavior enemyBehavior;
    private GameObject player;
    private Transform playerDirection;

    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player");
        enemyBehavior = gameObject.AddComponent<EnemyBehavior>();

        int playerLayer = LayerMask.NameToLayer("Enemy");
        int enemyLayer = LayerMask.NameToLayer("Laser");
        Physics.IgnoreLayerCollision(gameObject.layer, enemyLayer);
    }

    // Update is called once per frame
    void Update()
    {
        playerDirection = GameObject.FindGameObjectWithTag("Player").transform;
        playerDetected = enemyBehavior.getDetectPlayer();

        if (playerDetected)
        {
            if (Time.time > tempoUltimoDisparo + intervaloDisparo)
            {
                sound.Play();

                Vector3 direction = (playerDirection.position - transform.position).normalized;

                // Dispara o projetil
                GameObject novoProjetil = Instantiate(enemyLaser, transform.position, transform.rotation);
                novoProjetil.transform.forward = direction;

                // Aplica força ao projetil na direção da nave e atribui exclusão de objeto
                Rigidbody rb = novoProjetil.GetComponent<Rigidbody>();

                novoProjetil.transform.LookAt(player.transform);
                rb.AddForce(direction * velocidadeProjetil, ForceMode.VelocityChange);

                // Atualiza o tempo do último disparo
                tempoUltimoDisparo = Time.time;

                Destroy(novoProjetil, 3f);

            }
        }
         
    }
}
