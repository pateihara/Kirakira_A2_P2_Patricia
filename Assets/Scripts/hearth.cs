using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hearth : MonoBehaviour
{

    public Animator animator;
    [SerializeField] private AudioSource collectSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collectSoundEffect.Play();
            Player jogador = collider.GetComponent<Player>();
            jogador.RecebeVida();
            animator.SetTrigger("collect");

        }
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
