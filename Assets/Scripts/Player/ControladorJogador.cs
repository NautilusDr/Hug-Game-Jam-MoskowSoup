using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControladorJogador : MonoBehaviour
{
    private int contadorVagalume;

    InputAction acaoInteragir;

    public List<GameObject> vagalumesColetados = new List<GameObject>();

    void Start()
    {
        acaoInteragir = InputSystem.actions.FindAction("Interact");
        contadorVagalume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TravarVagalume();
    }

    public void TravarVagalume()
    {
        if(acaoInteragir.WasPerformedThisFrame()) 
        {
            if(vagalumesColetados.Count > 0)
            {
                vagalumesColetados[0].GetComponent<MovimentacaoVagalume>().estaPreso = true;
                vagalumesColetados.RemoveAt(0);

            }
        }
    }

    
}
