using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class armadilha : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.CompareTag("Player"))
        {
            Player jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            jogador.Morte();

        }
    }
}
