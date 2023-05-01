using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Life : MonoBehaviour
{
    public Player player;
    public TMP_Text lifeText;
    private float vida;

    void Start()
    {
        
    }

    void Update()
    {
        vida = player.getVida();
        lifeText.SetText("Vida: " + vida.ToString());
    }
}
