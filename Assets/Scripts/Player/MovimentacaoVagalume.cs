using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class MovimentacaoVagalume : MonoBehaviour
{
    private GameObject jogador;
    public float velocidadeBaseVagalume;
    public float velocidadeAtualVagalume;
    public float distanciaMinimaAteJogador;
    public float distanciaAteVagalumeVoltarJogador;

    public bool foiResgatado;

    public bool estaPreso;

    public bool podeRecolher;

    InputAction acaoInteragir;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        podeRecolher = false;
        estaPreso = false;
        foiResgatado = false;
        jogador = GameObject.FindGameObjectWithTag("Player");
        velocidadeAtualVagalume = velocidadeBaseVagalume;
        Physics2D.IgnoreLayerCollision(3, 15);

        acaoInteragir = InputSystem.actions.FindAction("Interact");

    }

    // Update is called once per frame
    void Update()
    {
        if (!estaPreso && foiResgatado)
        {
            Movimentacao();
        }
        if (Vector2.Distance(transform.position, jogador.transform.position) > distanciaAteVagalumeVoltarJogador)
        {
            estaPreso = false;
        }
    }

    void Movimentacao()
    {
        float distanciaAteJogador = Vector2.Distance(transform.position, jogador.transform.position);

        if (distanciaAteJogador > distanciaMinimaAteJogador)
        {
            if(distanciaAteJogador > distanciaMinimaAteJogador + 4)
            {
                velocidadeAtualVagalume = velocidadeBaseVagalume * 3;
            }
            else
            {
                velocidadeAtualVagalume = velocidadeBaseVagalume;
            }
            transform.position = Vector2.MoveTowards(transform.position, jogador.transform.position, velocidadeAtualVagalume * Time.deltaTime);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (acaoInteragir.IsPressed() && estaPreso)
            {
                estaPreso = false;
                collision.GetComponent<ControladorJogador>().vagalumesColetados.Add(gameObject);

            }

        }
    }

        private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!foiResgatado)
            {
                foiResgatado = true;

                collision.GetComponent<ControladorJogador>().vagalumesColetados.Add(gameObject);
            }
        }

    }  
}
