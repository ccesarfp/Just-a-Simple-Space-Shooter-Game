using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 0.0001f; // velocidade de movimento do objeto
    public float maxSpeed = 2.0f;
    public float minSpeed = 1.9f;
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
        float playerSpeed = rb.velocity.magnitude;
        float limitedSpeed = Mathf.Clamp(playerSpeed, minSpeed, maxSpeed);

        if (Input.GetKey(KeyCode.W))
        {
            if (rb.velocity.magnitude <= maxSpeed)
            {
                movement += transform.forward * speed;
            } else
            {
                Vector3 oppositeForce = rb.velocity.normalized * maxSpeed;
                rb.AddForce(-oppositeForce, ForceMode.Acceleration);
            }
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (rb.velocity.magnitude <= maxSpeed)
            {
                movement -= transform.forward * speed;
            }
            else
            {
                Vector3 oppositeForce = rb.velocity.normalized * maxSpeed;
                rb.AddForce(-oppositeForce, ForceMode.Acceleration);
            }
        }

        rb.AddForce(movement, ForceMode.VelocityChange);

        if (Mathf.Abs(Input.GetAxis("Vertical")) < 0.01f)
        {
            rb.velocity *= 0.99f;

        }

        float rotateHorizontal = Input.GetAxis("Horizontal");

        if (Mathf.Abs(rotateHorizontal) > 0f)
        {
            rb.velocity = rb.velocity.normalized * 0.95f;
        }

        // Virar o objeto com base na entrada do usu�rio
        transform.Rotate(Vector3.up, rotateHorizontal * rotationSpeed * Time.deltaTime);
    }
}
