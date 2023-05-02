using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VelocityDisplay : MonoBehaviour
{
    //Inicializa variáveis
    public Rigidbody player;
    public TMP_Text speedText;

    void Start()
    {
        
    }

    void Update()
    {
        //Captura velocidade
        float speed = player.velocity.magnitude;

        //Atualiza o texto com a velocidade atual do objeto
        speedText.text = speed.ToString("0.0");
    }
}
