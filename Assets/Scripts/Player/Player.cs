using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Inicializa variáveis de movimento
    public float speed = 0.02f; // velocidade de movimento do objeto
    public float maxSpeed = 3.0f;
    public float minSpeed = 2.9f;
    public float rotationSpeed = 25f; // velocidade de rotação do objeto

    //Inicializa variáveis de vida
    public float vidaInicial = 100f;
    private float vida;

    private float points = 0;

    //Inicializa Rigibody
    private Rigidbody rb; 

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Pega a referência do Rigibody
        vida = vidaInicial; //Atribui valor para vida atual
        Physics.IgnoreLayerCollision(0, 10);
    }

    void Update()
    {
        //Realiza gameover ##TODO
        if (vida <= 0f)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void FixedUpdate()
    {
        //Cria um vetor de movimento baseado nas teclas pressionadas e na velocidade
        Vector3 movement = new Vector3();
        float playerSpeed = rb.velocity.magnitude;

        if (Input.GetKey(KeyCode.W))
        {
            if (playerSpeed <= maxSpeed)
            {
                movement += transform.forward * speed;
            } else //Limita velocidade
            {
                limitSpeed();
            }
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (playerSpeed <= maxSpeed)
            {
                movement -= transform.forward * speed;
            }
            else //Limita velocidade
            {
                limitSpeed();
            }
        }

        //Aplica movimento
        rb.AddForce(movement, ForceMode.VelocityChange);

        //Reduz velocidade, caso jogador não esteja andando para frente/trás
        reduceVelocity();

        //Captura se jogador está usando teclas de movimentação lateral.
        float rotateHorizontal = Input.GetAxis("Horizontal");

        //Reduz velocidade, caso jogador esteja usando teclas horizontais
        reduceVelocityHorizontal(rotateHorizontal);

        //Vira o objeto com base na entrada do usuário
        transform.Rotate(Vector3.up, rotateHorizontal * rotationSpeed * Time.deltaTime);
    }

    /**
     * @name limitSpeed()
     * Realiza a limitação da velocidade do Player
     */
    public void limitSpeed()
    {
        Vector3 oppositeForce = rb.velocity.normalized * maxSpeed;
        rb.AddForce(-oppositeForce, ForceMode.Acceleration);
    }

    /**
     * @reduceVelocity()
     * Verifica se o jogador está indo para frente/trás.
     * Caso não esteja, irá reduzir a velocidade do mesmo.
     */
    public void reduceVelocity()
    {
        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.01f)
        {
            rb.velocity *= 0.99f;

        }
    }

    /**
     * @reduceVelocityHorizontal()
     * @params:
     *  float rotateHorizontal - Redebe valores gerados ao clicar em teclas de movimento horizontal
     * Essa função é responsável por limitar a velocidade do jogador, caso ele precione teclas horizontais
     */
    public void reduceVelocityHorizontal(float rotateHorizontal)
    {
        if (Mathf.Abs(rotateHorizontal) > 0f)
        {
            rb.velocity = rb.velocity.normalized * 0.95f;
            if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.01f)
            {
                rb.velocity = rb.velocity.normalized * 0.5f;
            }
        }
    }

    /**
     * @name getVida()
     * Retorna a vida atual do jogador
     */
    public float getVida()
    {
        return vida;
    }

    public void perderVida()
    {
        vida = vida - 5f;
    }

    public float getPoints()
    {
        return points;
    }

    public void aumentarPoints(float point)
    {
        points += point;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Laser_E"))
        {
            perderVida();
        }
    }
}
