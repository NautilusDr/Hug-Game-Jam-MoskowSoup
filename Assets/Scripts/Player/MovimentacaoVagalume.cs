using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using static UnityEngine.GraphicsBuffer;

public class MovimentacaoVagalume : MonoBehaviour
{
    InputAction acaoInteragir;
    private GameObject jogador;

    [Header("Movimentacao do Vagalume")]
    public float velocidadeBaseVagalume;
    public float velocidadeAtualVagalume;
    public float distanciaMinimaAteJogador;
    public float distanciaAteVagalumeVoltarJogador;

    [Header("Bool para permitir movimentacao")]
    public bool foiResgatado;
    public bool estaParado;   

    [Header("Controle de Luz")]
    public float intensidadeBrilhoParado;
    public float intensidadeBrilhoMovendo;
    Light2D luz;
    public CircleCollider2D colisorLuz;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        estaParado = true;
        //foiResgatado = false;
        jogador = GameObject.FindGameObjectWithTag("Player");
        velocidadeAtualVagalume = velocidadeBaseVagalume;
        Physics2D.IgnoreLayerCollision(3, 15);

        acaoInteragir = InputSystem.actions.FindAction("Interact");
        luz = GetComponentInChildren<Light2D>();
        colisorLuz.radius = intensidadeBrilhoParado + 1;

    }

    // Update is called once per frame
    void Update()
    {
        if(estaParado)
        {
        }
        else
        {
            Movimentacao();            
        }

        if (Vector2.Distance(transform.position, jogador.transform.position) > distanciaAteVagalumeVoltarJogador)
        {
            estaParado = false;
        }

    }

    void Movimentacao()
    {
        float distanciaAteJogador = Vector2.Distance(transform.position, jogador.transform.position);

        if (distanciaAteJogador > distanciaMinimaAteJogador)
        {
            if(distanciaAteJogador > distanciaAteVagalumeVoltarJogador/2)
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (estaParado)
            {
                estaParado = false;
                luz.pointLightOuterRadius = intensidadeBrilhoMovendo;
                colisorLuz.radius = intensidadeBrilhoMovendo * 2;
                collision.GetComponent<ControladorJogador>().vagalumesColetados.Add(gameObject);
            }
            else
            {
                estaParado = true;
                luz.pointLightOuterRadius = intensidadeBrilhoParado;
                colisorLuz.radius = intensidadeBrilhoParado * 2;
                collision.GetComponent<ControladorJogador>().vagalumesColetados.RemoveAt(0);
            }
        }

    }

}
