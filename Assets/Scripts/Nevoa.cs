using UnityEngine;

public class Nevoa : MonoBehaviour
{
    public bool lupa;
    public bool lupa2;
    public bool abrir;
    public Collider2D collider2d;
    public Animator animator;

    void Start()
    {
        abrir = false;
        lupa = false;
        lupa2 = false;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(lupa && lupa2)
        {
            DesativarNevoa();
        }
        else
        {
            AtivarNevoa();
        }
    }

    public void DesativarNevoa()
    {
        animator.SetTrigger("Sumir");
    }

    public void AtivarNevoa()
    {
        animator.SetTrigger("Aparecer");
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

    public void AtivarColisor()
    {
        collider2d.enabled = true; 
    }

    public void DesativarColisor()
    {
        collider2d.enabled = false;
    }

}
