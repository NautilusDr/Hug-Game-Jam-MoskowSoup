using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MovimentacaoVagalume : MonoBehaviour
{
    private GameObject jogador;
    public float velocidadeBaseVagalume;
    public float velocidadeAtualVagalume;
    public float distanciaMinimaAteJogador;

    public bool estaPreso;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player");
        velocidadeAtualVagalume = velocidadeBaseVagalume;
        Physics2D.IgnoreLayerCollision(3, 15);
    }

    // Update is called once per frame
    void Update()
    {
        if (!estaPreso)
        {
            Movimentacao();
        }
    }

    void Movimentacao()
    {
        float distanciaAteJogador = Vector2.Distance(transform.position, jogador.transform.position);

        if(distanciaAteJogador > distanciaMinimaAteJogador)
        {
            if(distanciaAteJogador > distanciaMinimaAteJogador + 4)
            {
                velocidadeAtualVagalume = velocidadeBaseVagalume * 2;
            }
            else
            {
                velocidadeAtualVagalume = velocidadeBaseVagalume;
            }
            transform.position = Vector2.MoveTowards(transform.position, jogador.transform.position, velocidadeAtualVagalume * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            estaPreso = false;
        }
    }
}
