using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Life : MonoBehaviour
{
    //Inicializa varáveis para vriar a barra de vida
    public Player player;
    public TMP_Text lifeText;
    private float vida;

    void Start()
    {
        
    }

    void Update()
    {
        //Atribui a vida e apresenta para o jogador
        vida = player.getVida();
        lifeText.SetText("Vida: " + vida.ToString());
    }
}
