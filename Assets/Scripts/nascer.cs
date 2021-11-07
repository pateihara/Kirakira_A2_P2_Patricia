using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nascer : MonoBehaviour
{
    public GameObject enemies;
    public Transform[] spawnPoint;


    public void Start()
    {
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke(nameof(Nascer), 0.5f);
        }
    }


    public void Nascer()
    {
        for (int i = 0; i < 5; i++)
        {
            Instantiate(enemies, spawnPoint[Random.Range(0, spawnPoint.Length)]);
        }
    }

    public void Esconder()
    {
        this.gameObject.SetActive(false);
    }


}
