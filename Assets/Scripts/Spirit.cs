using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spirit : MonoBehaviour
{

    public Animator animator;
    public int pontuacao = 3;
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
            Player.Pontuacao += pontuacao;
            SceneManager.LoadScene("MensagemFim");

        }

    }
}
