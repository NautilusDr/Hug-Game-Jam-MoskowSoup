using UnityEngine;

public class MovimentacaoCamera : MonoBehaviour
{
    public GameObject[] posicaoCameraPorSala;
    public float velocidadeCamera;
    public int proximaSala;
    Vector3 caminho;

    private void Awake()
    {
        proximaSala = 0;
    }

    private void FixedUpdate()
    {
        MoverCameraEntreSalas();
    }

    public void MoverCameraEntreSalas()
    {
        transform.position = Vector3.MoveTowards(transform.position, caminho, velocidadeCamera * Time.deltaTime); /*new Vector3(posicaoCameraPorSala[proximaSala].transform.position.x, posicaoCameraPorSala[proximaSala].transform.position.y, posicaoCameraPorSala[proximaSala].transform.position.z-10);*/
    }

    public void DefinirProximaSala(int sala)
    {
        proximaSala = sala;
        caminho = new Vector3(posicaoCameraPorSala[proximaSala].transform.position.x, posicaoCameraPorSala[proximaSala].transform.position.y, posicaoCameraPorSala[proximaSala].transform.position.z - 10);

    }
}
