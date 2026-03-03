using UnityEngine;

public class Nevoa : MonoBehaviour
{
    public bool lupa;
    public Collider2D collider2d;
    public Animator animator;


    void Start()
    {
        lupa = false;
        animator = GetComponent<Animator>();
        collider2d = GetComponent<Collider2D>();
    }

    void Update()
    {
        if(lupa)
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
            DesativarNevoa();
        }

       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lupa"))
        {
            lupa = false;
            AtivarNevoa();
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
