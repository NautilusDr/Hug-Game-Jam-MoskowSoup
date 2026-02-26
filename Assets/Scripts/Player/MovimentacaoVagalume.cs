using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MovimentacaoVagalume : MonoBehaviour
{
    private GameObject jogador;
    public float velocidadeVagalume;
    public float distanciaMinimaAteJogador;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreLayerCollision(3, 15);
    }

    // Update is called once per frame
    void Update()
    {
        Movimentacao();
    }

    void Movimentacao()
    {
        float distanciaAteJogador = Vector2.Distance(transform.position, jogador.transform.position);

        if(distanciaAteJogador > distanciaMinimaAteJogador)
        {
            transform.position = Vector2.MoveTowards(transform.position, jogador.transform.position, velocidadeVagalume * Time.deltaTime);
        }
    }
}
