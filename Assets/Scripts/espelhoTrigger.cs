using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class espelhoTrigger : MonoBehaviour
{
    public GameObject mirror;
    public Transform[] spawnPoint;
    public int espelhos = 1;
    public void Start()
    {

    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke(nameof(EspelhoNascer), 2f);
        }
    }


    public void EspelhoNascer()
    {
        for (int i = 0; i < 1; i++)
        {
            Instantiate(mirror, spawnPoint[Random.Range(0, spawnPoint.Length)]);
        }
    }


    public void Esconder()
    {
        this.gameObject.SetActive(false);
    }


}

