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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        velocidadeAtualJogador = velocidadeBaseJogador;
        jogadorRigidBody2D = GetComponent<Rigidbody2D>();
        acaoMovimento = InputSystem.actions.FindAction("Move");
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
    }


}
