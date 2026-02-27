using UnityEngine;

public class AtivarNaLuz : MonoBehaviour
{
    public MonoBehaviour[] script;

    private void Awake()
    {
        for (int i = 0; i < script.Length; i++)
        {
            script[i].enabled = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Vagalume"))
        {
            for (int i = 0; i < script.Length; i++)
            {
                script[i].enabled = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Vagalume"))
        {
            for (int i = 0; i < script.Length; i++)
            {
                script[i].enabled = false;
            }
        }
    }
}
