using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agua : MonoBehaviour
{
    private Player playzinho;
    private float tempo;

    public void OnTriggerStay2D(Collider2D collider)
    {

        tempo = tempo + Time.deltaTime;

        if (collider.CompareTag("Player") && tempo > 20 )
        {
            Player jogador = collider.GetComponent<Player>();
            jogador.ReceberDano();
            tempo = 0;
        }
    }


    public void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("Player") )
        {
            Player playzinho = collider.GetComponent<Player>();
            playzinho.ReceberDano();
        }
    }
}
