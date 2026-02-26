using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class MovimentacaoTopDownPlayer : MonoBehaviour
{
    private Vector2 direcaoMovimentoJogador;
    public float velocidadeBaseJogador;
    private float velocidadeAtualJogador;
    public Rigidbody2D jogadorRigidBody2D;

    InputAction moveAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        velocidadeAtualJogador = velocidadeBaseJogador;
        jogadorRigidBody2D = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        Vector2 velocidadeMovimentacao = moveValue * velocidadeBaseJogador;

        jogadorRigidBody2D.linearVelocity = velocidadeMovimentacao;
        //float direcaoMovimentoX = InputSystem.actions.FindAction("move");
        //float direcaoMovimentoY = 
        //direcaoMovimentoJogador = new Vector2(direcaoMovimentoX, direcaoMovimentoY).normalized;
    }

    void FixedUpdate()
    {
        Movimentacao();
    }

    void Movimentacao()
    {
        
    }
}
