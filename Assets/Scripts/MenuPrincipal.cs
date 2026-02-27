using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    void Start()
    {
        
    }

    public void BotaoJogar(string nomeDaCena)
    {
        SceneManager.LoadScene(nomeDaCena);
    }

    public void BotaoAi()
    {
        Debug.Log("Este Botao definitivamente é um Botao");
    }

    public void BotaoSair()
    {
        Application.Quit();
    }
}
