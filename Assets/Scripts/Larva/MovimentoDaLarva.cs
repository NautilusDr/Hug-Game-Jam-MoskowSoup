using UnityEngine;
public class MovimentoDaLarva : MonoBehaviour
{
    [Header("Atributos")]
    public float velocidade;

    [Header("Componentes")]
    public Transform posicaoPlayer;
    public Rigidbody2D rbLarva;
    Animator animator;
    GameObject jogador;
    

    void Start()
    {
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
        animator.SetFloat("moveX", moveValue.x);
        animator.SetFloat("moveY", moveValue.y);
        animator.SetBool("isMoving", moveValue != Vector2.zero);

        if (MovimentacaoVagalume.larvaPodeAndar == true)
        {
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


}
