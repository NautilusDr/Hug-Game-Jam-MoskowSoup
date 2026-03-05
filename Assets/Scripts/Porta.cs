using UnityEngine;

public class Porta : MonoBehaviour
{
    GameObject jogador;
    Animator animator;
    public Collider2D colisor;

    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (jogador.GetComponent<ControladorJogador>().vagalumesColetados.Count == 4)
        {
            animator.SetBool("AbrirPorta", true);
        }
        else
        {
            animator.SetBool("AbrirPorta", false);
        }
    }

    public void AtivarColisor()
    {
        colisor.enabled = true;
    }

    public void DesativarColisor()
    {
        colisor.enabled = false;
    }
}
