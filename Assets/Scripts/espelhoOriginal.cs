using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class espelhoOriginal : MonoBehaviour
{
    private nascer spwanTrigger;
    private espelhoTrigger espelhoT;
    private Player playzinho;


    public Animator animator;
    [SerializeField] private AudioSource collectSoundsEffects;
    public int espelho = 1;


    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (Player.Espelho == 3)
        {
            GameObject spawn = GameObject.FindGameObjectWithTag("spawn");
            this.spwanTrigger = spawn.GetComponent<nascer>();
            this.spwanTrigger.Esconder();

            GameObject espelhoO = GameObject.FindGameObjectWithTag("mirror");
            this.espelhoT = espelhoO.GetComponent<espelhoTrigger>();
            this.espelhoT.Esconder();

            GameObject playFire = GameObject.FindGameObjectWithTag("Player");
            this.playzinho = playFire.GetComponent<Player>();
            this.playzinho.fireBall();

            Debug.Log("acionou");
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            collectSoundsEffects.Play();
            animator.SetTrigger("collect");

            Player.Espelho += espelho;
        }
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
