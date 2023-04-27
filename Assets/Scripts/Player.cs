using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 0.0001f; // velocidade de movimento do objeto
    public float rotationSpeed = 10f; // velocidade de rota��o do objeto

    private Rigidbody rb; // refer�ncia ao Rigidbody do objeto

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // pega a refer�ncia do Rigidbody
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // cria um vetor de movimento baseado nas teclas pressionadas e na velocidade
        Vector3 movement = new Vector3();

        if (Input.GetKey(KeyCode.W))
        {
            movement += transform.forward * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement -= transform.forward * speed;
        }

        // aplica a for�a no objeto usando o Rigidbody
        rb.AddForce(movement, ForceMode.VelocityChange);

        //Captura acionamento de rota��o
        float rotateHorizontal = Input.GetAxis("Horizontal");

        // Virar o objeto com base na entrada do usu�rio
        transform.Rotate(Vector3.up, rotateHorizontal * rotationSpeed * Time.deltaTime);
    }
}
