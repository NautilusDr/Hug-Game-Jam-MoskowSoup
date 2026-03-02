using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class MovimentacaoTopDownPlayer : MonoBehaviour
{
    InputAction acaoMovimento;


    [Header("Movimento do Jogador")]
    public float velocidadeBaseJogador;
    public float velocidadeAtualJogador;
    public Rigidbody2D jogadorRigidBody2D;
    private Animator animator;
    public SpriteRenderer spriteRenderer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        velocidadeAtualJogador = velocidadeBaseJogador;
        jogadorRigidBody2D = GetComponent<Rigidbody2D>();
        acaoMovimento = InputSystem.actions.FindAction("Move");
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Movimentacao();       
    }

    void Movimentacao()
    {

        Vector2 moveValue = acaoMovimento.ReadValue<Vector2>();
        Vector2 velocidadeMovimentacao = moveValue * velocidadeAtualJogador;

        jogadorRigidBody2D.linearVelocity = velocidadeMovimentacao;

        bool estaMovendo = moveValue != Vector2.zero;
        animator.SetFloat("moveX", moveValue.x);
        animator.SetFloat("moveY", moveValue.y);
        animator.SetBool("isMoving", moveValue != Vector2.zero);

        if(moveValue.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveValue.x < 0)
        {
            spriteRenderer.flipX= true;
        }
        else if (!estaMovendo)
        {
            spriteRenderer.flipX = false;
        }
    }


}
