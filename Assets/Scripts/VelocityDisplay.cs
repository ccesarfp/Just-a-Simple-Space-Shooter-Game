using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VelocityDisplay : MonoBehaviour
{

    public Rigidbody player;
    public TMP_Text speedText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = player.velocity.magnitude;

        // Atualize o texto com a velocidade atual do objeto
        speedText.text = speed.ToString("0.0");
    }
}
