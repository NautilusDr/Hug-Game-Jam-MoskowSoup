using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using static UnityEngine.GraphicsBuffer;

public class MovimentacaoVagalume : MonoBehaviour
{
    private GameObject jogador;
    Animator animator;

    [Header("Movimentacao do Vagalume")]
    public float velocidadeBaseVagalume;
    public float velocidadeAtualVagalume;
    public float distanciaMinimaAteJogador;
    public float distanciaAteVagalumeVoltarJogador;

    [Header("Bool para permitir movimentacao")]
    public bool foiResgatado;
    public bool estaParado;
    public bool estaAbajur;
    public bool estaLupa;

    [Header("Controle de Luz")]
    public float intensidadeBrilhoParado;
    public float intensidadeBrilhoMovendo;
    [HideInInspector] public Light2D luz;
    public CircleCollider2D colisorLuz;

    [Header("Componente da larva")]
    public static bool larvaPodeAndar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        estaParado = true;
        estaAbajur = false;
        foiResgatado = false;
        larvaPodeAndar = false;
        
        jogador = GameObject.FindGameObjectWithTag("Player");
        velocidadeAtualVagalume = velocidadeBaseVagalume;
        Physics2D.IgnoreLayerCollision(3, 15);
        Physics2D.IgnoreLayerCollision(14, 15);
        luz = GetComponentInChildren<Light2D>();
        luz.pointLightOuterRadius = intensidadeBrilhoParado * 0.5f;
        colisorLuz.radius = intensidadeBrilhoParado;

        animator = GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        if (foiResgatado && !estaAbajur && !estaLupa)
        {
            if (!estaParado)
            {
                Movimentacao();
            }
            else if (Vector2.Distance(transform.position, jogador.transform.position) > distanciaAteVagalumeVoltarJogador)
            {
                estaParado = false;
                colisorLuz.radius = intensidadeBrilhoMovendo * 0.5f;
                luz.pointLightOuterRadius = intensidadeBrilhoMovendo;
                AdicionarVagalume();
            }
        }

        if (estaParado || estaAbajur || estaLupa)
        {
            animator.SetBool("EstaParado", true);
        }
        else
        {
            animator.SetBool("EstaParado", false);
        }
    }

    void Movimentacao()
    {
        float distanciaAteJogador = Vector2.Distance(transform.position, jogador.transform.position);

        if (distanciaAteJogador > distanciaMinimaAteJogador)
        {
            if(distanciaAteJogador > distanciaAteVagalumeVoltarJogador * 0.5f)
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

    public void EntrarAbajur()
    {
        estaAbajur = true;
        colisorLuz.radius = intensidadeBrilhoParado;
        luz.pointLightOuterRadius = intensidadeBrilhoParado * 2;
    }

    public void SairAbajur()
    {
        estaAbajur = false;
        colisorLuz.radius = intensidadeBrilhoMovendo * 0.5f;
        luz.pointLightOuterRadius = intensidadeBrilhoMovendo;
    }

    public void EntrarLupa(GameObject lupa)
    {
        estaLupa = true;
        transform.parent = lupa.transform;
        colisorLuz.radius = 1;
        luz.pointLightOuterRadius = intensidadeBrilhoParado;
        luz.falloffIntensity = 0.15f;
        luz.pointLightInnerAngle = 0;
        luz.pointLightOuterAngle = 60;
        transform.rotation = lupa.transform.rotation;
    }

    public void SairLupa()
    {
        estaLupa = false;
        transform.parent = null;
        colisorLuz.radius = intensidadeBrilhoMovendo * 0.5f;
        luz.pointLightOuterRadius = intensidadeBrilhoMovendo;
        luz.falloffIntensity = 0.5f; 
        luz.pointLightInnerAngle = 360;
        luz.pointLightOuterAngle = 360;
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Larva"))
        {
            if (colisorLuz.IsTouching(collision))
            {
                larvaPodeAndar = true;
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !estaAbajur && !estaLupa)
        {
            if (!foiResgatado)
            {
                foiResgatado = true;
            }
            if (estaParado)
            {
                estaParado = false;
                luz.pointLightOuterRadius = intensidadeBrilhoMovendo;
                colisorLuz.radius = intensidadeBrilhoMovendo * 0.5f;
                AdicionarVagalume();
                //collision.GetComponent<ControladorJogador>().vagalumesColetados.Add(gameObject);
            }
            else
            {
                estaParado = true;
                luz.pointLightOuterRadius = intensidadeBrilhoParado;
                colisorLuz.radius = intensidadeBrilhoParado * 0.5f;
                RemoverVagalume();
            }
        }

        if (collision.gameObject.CompareTag("Larva"))
        {
            if (!colisorLuz.IsTouching(collision))
            {
                larvaPodeAndar = false;
            }
        }

    }

    void AdicionarVagalume()
    {
        jogador.GetComponent<ControladorJogador>().vagalumesColetados.Add(gameObject);
    }

    void RemoverVagalume()
    {
        jogador.GetComponent<ControladorJogador>().vagalumesColetados.RemoveAt(0);
    }
}
