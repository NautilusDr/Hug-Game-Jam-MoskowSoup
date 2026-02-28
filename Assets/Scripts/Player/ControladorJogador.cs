using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorJogador : MonoBehaviour
{
    InputAction acaoInteragir;

    [Header("Lista de Vagalumes seguindo o jogador")]
    public List<GameObject> vagalumesColetados = new List<GameObject>();

    void Start()
    {
        acaoInteragir = InputSystem.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {
    }


}

