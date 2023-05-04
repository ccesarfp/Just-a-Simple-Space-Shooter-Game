using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    public TMP_Text pointsText;
    public Player player;
    private float points;

    void Start()
    {
        
    }

    void Update()
    {
        //Atribui a vida e apresenta para o jogador
        points = player.getPoints();
        pointsText.SetText(points.ToString());
    }
}
