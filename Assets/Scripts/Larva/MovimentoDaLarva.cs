using UnityEngine;
public class MovimentoDaLarva : MonoBehaviour
{
    [Header("Atributos")]
    public float velocidade;

    [Header("Componentes")]
    public Transform posicaoPlayer;
    public Rigidbody2D rbLarva;
    

    void Start()
    {

        rbLarva = GetComponent<Rigidbody2D>();   
    }



    private void FixedUpdate()
    {
        if (MovimentacaoVagalume.larvaPodeAndar == true)
        {
            MovimentacaoLarva();
        }
        else if(MovimentacaoVagalume.larvaPodeAndar == false)
        {
            PararLarva();
        }
    }

    void MovimentacaoLarva()
    {

        Vector2 direcao = (posicaoPlayer.position - transform.position).normalized; rbLarva.linearVelocity = direcao * velocidade;
    }

    void PararLarva()
    {
        rbLarva.linearVelocity = Vector2.zero;
    }


}
