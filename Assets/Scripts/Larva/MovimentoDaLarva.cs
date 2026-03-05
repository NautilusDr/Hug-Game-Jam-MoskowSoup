using UnityEngine;
public class MovimentoDaLarva : MonoBehaviour
{
    [Header("Atributos")]
    public float velocidade;

    [Header("Componentes")]
    public Transform posicaoPlayer;
    public Rigidbody2D rbLarva;
    public Animator animator;
    GameObject jogador;
    public SpriteRenderer spriteRenderer;
    public bool comendoFolha = false;
    

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rbLarva = GetComponent<Rigidbody2D>();
        jogador = GameObject.FindGameObjectWithTag("Player");
    }



    private void FixedUpdate()
    {

        Vector2 moveValue = new Vector2(rbLarva.linearVelocityX, rbLarva.linearVelocityY);
        Vector2 velocidadeMovimentacao = moveValue * velocidade;

        rbLarva.linearVelocity = velocidadeMovimentacao;
        bool estaMovendo = moveValue != Vector2.zero;
        animator.SetFloat("MoveLX", moveValue.x);
        animator.SetFloat("MoveLY", moveValue.y);
        animator.SetBool("IsLMoving", moveValue != Vector2.zero);

        if (moveValue.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveValue.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (!estaMovendo)
        {
            spriteRenderer.flipX = false;
        }


        if (MovimentacaoVagalume.larvaPodeAndar == true)
        {
            if (comendoFolha)
            {
                PararLarva();
                return;
            }
            MovimentacaoLarva();

        }
        else if(MovimentacaoVagalume.larvaPodeAndar == false)
        {
            PararLarva();
        }
    }

    void MovimentacaoLarva()
    {

        Vector2 direcao = (posicaoPlayer.position - transform.position).normalized; rbLarva.linearVelocity = direcao * velocidade;
    }

    void PararLarva()
    {
        rbLarva.linearVelocity = Vector2.zero;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Folha"))
        {
            animator.SetTrigger("Folha");
            PararLarva();
            comendoFolha = true;
        }
    }

}
