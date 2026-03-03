using UnityEngine;

public class Nevoa : MonoBehaviour
{
    public bool lupa;
    public bool lupa2;
    public bool abrir;

    void Start()
    {
        abrir = false;
        lupa = false;
        lupa2 = false;
    }

    void Update()
    {
        if(lupa && lupa2)
        {
            gameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lupa"))
        {
            lupa = true;
        }

        if (collision.gameObject.CompareTag("Lupa2"))
        {
            lupa2 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lupa"))
        {
            lupa = false;
        }

        if (collision.gameObject.CompareTag("Lupa2"))
        {
            lupa2 = false;
        }
    }
}
