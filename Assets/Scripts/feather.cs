using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feather : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private Rigidbody2D rgbd;
    [SerializeField] private AudioSource explosionSoundsEffects;

    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            rgbd.bodyType = RigidbodyType2D.Static;
            animator.SetTrigger("explosion");
            explosionSoundsEffects.Play();
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            rgbd.bodyType = RigidbodyType2D.Static;
            Player jogador = collision.GetComponent<Player>();
            jogador.ReceberDano();
            animator.SetTrigger("explosion");
            explosionSoundsEffects.Play();
        }
    }
    public void Destroy(){
        Destroy(this.gameObject);
    }
}
