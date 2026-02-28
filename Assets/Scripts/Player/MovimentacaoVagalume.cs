using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
using static UnityEngine.GraphicsBuffer;

public class MovimentacaoVagalume : MonoBehaviour
{
    private GameObject jogador;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        estaParado = true;
        estaAbajur = false;
        
        jogador = GameObject.FindGameObjectWithTag("Player");
        velocidadeAtualVagalume = velocidadeBaseVagalume;
        Physics2D.IgnoreLayerCollision(3, 15);
        luz = GetComponentInChildren<Light2D>();
        luz.pointLightOuterRadius = intensidadeBrilhoParado/2;
        colisorLuz.radius = intensidadeBrilhoParado;

    }

    // Update is called once per frame
    void Update()
    {
        if(!estaParado && !estaAbajur && !estaLupa)
        {
            Movimentacao();
        }

        if (Vector2.Distance(transform.position, jogador.transform.position) > distanciaAteVagalumeVoltarJogador && !estaAbajur)
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

    public void EntrarAbajur()
    {
        estaAbajur = true;
        colisorLuz.radius = intensidadeBrilhoParado * 4;
        luz.pointLightOuterRadius = intensidadeBrilhoParado * 2;
    }

    public void SairAbajur()
    {
        estaAbajur = false;
        colisorLuz.radius = intensidadeBrilhoMovendo;
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
        colisorLuz.radius = intensidadeBrilhoMovendo *2;
        luz.pointLightOuterRadius = intensidadeBrilhoMovendo;
        luz.falloffIntensity = 0.5f; 
        luz.pointLightInnerAngle = 360;
        luz.pointLightOuterAngle = 360;
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !estaAbajur)
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
