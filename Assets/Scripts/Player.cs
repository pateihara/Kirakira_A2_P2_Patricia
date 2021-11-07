using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    float move;
    [SerializeField] private Rigidbody2D rgbd;
    public int velocidade = 5;
    private Vector3 facingRight;
    private Vector3 facingLeft;
    public int jump = 5;
    public bool taNoChao;
    public Transform detectaChao;
    public LayerMask oQueEhChao;

    public Animator animator;
    private float vertical;
    private float speed = 8f;
    private bool isClimbing;
    private bool isLadder;
    public static int pontuacao;
    public static int espelho;
    private int vidaMaxima = 10;
    public int vidaAtual;
    public GameObject fireball;
    private float tempo;


    [SerializeField] private AudioSource deathSoundEffects;
    [SerializeField] private AudioSource hitSoundEffects;


    void Start()
    {
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * -1;
        rgbd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        pontuacao = 0;
        vidaAtual = vidaMaxima;
        espelho = 0;
        animator.SetTrigger("idle");

    }



    void Update()
    {

        taNoChao = Physics2D.OverlapCircle(detectaChao.position, 0.1f, oQueEhChao);

        if (Input.GetButtonDown("Jump") && taNoChao == true)
        {
            rgbd.velocity = Vector2.up * jump;
            animator.SetBool("jump", true);
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            //está correndo
            animator.SetBool("walk", true);

        }
        else
        {
            //está parado
            animator.SetBool("walk", false);
        }

        if (taNoChao && rgbd.velocity.y == 0)
        {
            animator.SetBool("jump", false);
        }


        vertical = Input.GetAxis("Vertical");
        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }

    }

    private void FixedUpdate()
    {
        move = Input.GetAxis("Horizontal"); //-1~1
        move *= velocidade;

        rgbd.velocity = new Vector2(move, rgbd.velocity.y);

        if (move > 0)
        {
            transform.localScale = facingRight;
        }
        if (move < 0)
        {
            transform.localScale = facingLeft;
        }

        if (isClimbing)
        {
            rgbd.gravityScale = 0f;
            rgbd.velocity = new Vector2(rgbd.velocity.x, vertical * speed);
        }
        else
        {
            rgbd.gravityScale = 1f;
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isLadder = true;
            isClimbing = true;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;

        }

    }

    public static int Pontuacao
    {
        get
        {
            return pontuacao;
        }
        set
        {
            pontuacao = value;
            if (pontuacao < 0)
            {
                pontuacao = 0;
            }
            Debug.Log("Pontuação atualizada para:" + Pontuacao);

        }
    }

    public static int Espelho
    {
        get
        {
            return espelho;
        }
        set
        {
            espelho = value;
            if (espelho < 0)
            {
                espelho = 0;
            }
            Debug.Log("Espelho:" + Espelho);

        }
    }

    public void RecebeVida()
    {
        vidaAtual += 5;
    }


    public void ReceberDano()
    {
        vidaAtual -= 1;
        hitSoundEffects.Play();
        animator.SetTrigger("hit");


        if (vidaAtual <= 0)
        {
            Morte();
        }
    }


    public void Morte()
    {
        rgbd.bodyType = RigidbodyType2D.Static;
        deathSoundEffects.Play();
        animator.SetTrigger("death");
        animator.ResetTrigger("hit");
        Debug.Log("aqui morte");
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        pontuacao = 0;
    }

    public void fireBall()
    {
        fireball.GetComponent<Animator>().SetTrigger("descer");
    }

}
