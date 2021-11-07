using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoFogo : MonoBehaviour
{
    private float tempo = 0;

     public void OnTriggerStay2D(Collider2D collider)
    {
        
        tempo = tempo + Time.deltaTime;

        if (collider.CompareTag("Player") && tempo >8)
        {
            Player jogador = collider.GetComponent<Player>();
            jogador.ReceberDano();
            tempo = 0;
        }   
    }
         public void OnTriggerEnter2D(Collider2D collider)
    {        
        if (collider.CompareTag("Player"))
        {
            Player jogador = collider.GetComponent<Player>();
            jogador.ReceberDano();
        }   
    }
}
