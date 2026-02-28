using UnityEngine;
using UnityEngine.InputSystem;

public class Lupa : MonoBehaviour
{
    InputAction acaoInteragir;
    InputAction acaoRotacionarEsquerda;
    InputAction acaoRotacionarDireita;
    GameObject jogador;
    ControladorJogador controladorJogador;
    public GameObject vagalume;
    public float velocidadeRotacao;

    public bool estaNaLuz;
    public bool possuiVagalume;
    public bool podeInteragirLupa;

    void Start()
    {
        acaoInteragir = InputSystem.actions.FindAction("Interact");
        acaoRotacionarEsquerda = InputSystem.actions.FindAction("Previous");
        acaoRotacionarDireita = InputSystem.actions.FindAction("Next");

        jogador = GameObject.FindGameObjectWithTag("Player");
        controladorJogador = jogador.GetComponent<ControladorJogador>();
        estaNaLuz = false;
        possuiVagalume = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (estaNaLuz && podeInteragirLupa)
        {
            InteragirLupa();
            RotacionarLupa();
        }
    }

    public void InteragirLupa()
    {
        if (acaoInteragir.WasPressedThisFrame())
        {
            if(!possuiVagalume && controladorJogador.vagalumesColetados.Count > 0)
            {
                possuiVagalume = true;
                vagalume = controladorJogador.vagalumesColetados[0];
                vagalume.transform.position = transform.position;
                vagalume.GetComponent<MovimentacaoVagalume>().EntrarLupa(gameObject);                
                controladorJogador.vagalumesColetados.RemoveAt(0);
            }
            else
            {
                possuiVagalume = false;
                vagalume.GetComponent<MovimentacaoVagalume>().SairLupa();
                
                controladorJogador.vagalumesColetados.Add(vagalume);
            }
        }
    }

    public void RotacionarLupa()
    {
        if (acaoRotacionarDireita.IsPressed())
        {
            transform.Rotate(0, 0, -(velocidadeRotacao * Time.deltaTime));
        }

        if (acaoRotacionarEsquerda.IsPressed())
        {
            transform.Rotate(0, 0, (velocidadeRotacao * Time.deltaTime));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Vagalume"))
        {
            estaNaLuz = true;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            podeInteragirLupa = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Vagalume"))
        {
            estaNaLuz = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Vagalume") && estaNaLuz)
        {
            estaNaLuz = false;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            podeInteragirLupa = false;
        }
    }

}
