using UnityEngine;
using UnityEngine.Events;

public class AtivarComContato : MonoBehaviour
{
    [Header("Evento")]
    public UnityEvent evento;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (evento != null)
            {
                evento.Invoke();
                //Debug.Log("Evento invocado");
            }
        }
    }
}
