using UnityEngine;

public class MovimentacaoCamera : MonoBehaviour
{
    public GameObject[] posicaoCameraPorSala;
    public GameObject[] posicaoDoJogador;
    public float velocidadeCamera;
    public int proximaSala;
    public int proximaLocJogador;
    Vector3 caminho;
    public Transform transformPlayer;

    private void Awake()
    {
        proximaSala = 0;
        DefinirProximaSala(0);
    }

    private void FixedUpdate()
    {
        MoverCameraEntreSalas();

        if (proximaSala == 0)
        {
            transformPlayer.localScale = new Vector3(6f, 6f, 3f);
        }

        else if (proximaSala == 1)
        {
            transformPlayer.localScale = new Vector3(6f, 6f, 3f);
        }
        else if (proximaSala == 2)
        {
            transformPlayer.localScale = new Vector3(4f, 4f, 3f);
        }
    }

    public void MoverCameraEntreSalas()
    {
        transform.position = new Vector3(caminho.x, caminho.y, transform.position.z); /*new Vector3(posicaoCameraPorSala[proximaSala].transform.position.x, posicaoCameraPorSala[proximaSala].transform.position.y, posicaoCameraPorSala[proximaSala].transform.position.z-10);*/
    }

    public void DefinirProximaSala(int sala)
    {
        proximaSala = sala;
        caminho = new Vector3(posicaoCameraPorSala[proximaSala].transform.position.x, posicaoCameraPorSala[proximaSala].transform.position.y, posicaoCameraPorSala[proximaSala].transform.position.z - 10);
    }
    public void TeleporteJogador(int teleporte)
    {
        proximaLocJogador = teleporte;
        transformPlayer.position = posicaoDoJogador[proximaLocJogador].transform.position;
    }
}
