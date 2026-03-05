using UnityEngine;
using UnityEngine.Events;

public class BotaoInvisivel : MonoBehaviour
{
    public UnityEvent evento;
    public GameObject[] Abajur;

    public bool abajur1;
    public bool abajur2;
    public bool abajur3;

    public bool podeInteragir;

    SpriteRenderer sprite;

    void Start()
    {
        abajur1 = false; 
        abajur2 = false; 
        abajur3 = false;
        sprite = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if (abajur1 && abajur2 && abajur3)
        {
            podeInteragir = true;
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
        }
        else
        {
            podeInteragir = false;

            if (abajur1 && abajur2 || abajur1 && abajur3 || abajur2 && abajur3)
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.6f);
            }
            else if (abajur1 || abajur2 || abajur3)
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.3f);
            }
            else
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);
            }
        }

        if (Abajur[0].GetComponent<Abajur>().possuiVagalume)
        {
            abajur1 = true;
        }
        else
        {
            abajur1 = false;
        }

        if (Abajur[1].GetComponent<Abajur>().possuiVagalume)
        {
            abajur2 = true;
        }
        else
        {
            abajur2 = false;
        }

        if (Abajur[2].GetComponent<Abajur>().possuiVagalume)
        {
            abajur3 = true;
        }
        else
        {
            abajur3 = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && podeInteragir)
        {
            evento.Invoke();
        }
    }

}
