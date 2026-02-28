using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Abajur : MonoBehaviour
{
    InputAction acaoInteragir;
    GameObject jogador;
    ControladorJogador controladorJogador;
    GameObject vagalume;

    public bool estaNaLuz;
    public bool possuiVagalume;
    public bool podeInteragirAbajur;


    void Start()
    {
        acaoInteragir = InputSystem.actions.FindAction("Interact");
        jogador = GameObject.FindGameObjectWithTag("Player");
        controladorJogador = jogador.GetComponent<ControladorJogador>();
        estaNaLuz = false;
        possuiVagalume = false;
    }

    void Update()
    {
        if (estaNaLuz && podeInteragirAbajur)
        {
            InteragirComAbajur();
        }
    }

    void InteragirComAbajur()
    {
        if (acaoInteragir.WasPressedThisFrame())
        {
            if (!possuiVagalume)
            {
                if(controladorJogador.vagalumesColetados.Count > 0)
                {
                    possuiVagalume = true;
                    vagalume = controladorJogador.vagalumesColetados[0];
                    vagalume.transform.position = transform.position;
                    vagalume.GetComponent<MovimentacaoVagalume>().EntrarAbajur();
                    controladorJogador.vagalumesColetados.RemoveAt(0);
                }
            }
            else
            {
                possuiVagalume = false;
                vagalume.GetComponent<MovimentacaoVagalume>().SairAbajur();
                controladorJogador.vagalumesColetados.Add(vagalume);
            }
           
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
            podeInteragirAbajur = true;
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
            podeInteragirAbajur = false;
        }
    }
}
