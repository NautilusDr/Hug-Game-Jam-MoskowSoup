using UnityEngine;

public class Nevoa : MonoBehaviour
{

    public Collider2D collider2d;
    public Animator animator;

    public float qtdDeLuz;


    void Start()
    {
        animator = GetComponent<Animator>();
        collider2d = GetComponent<Collider2D>();

        animator.SetBool("Visivel", true);

        qtdDeLuz = 0;
    }

    void Update()
    {
        if(qtdDeLuz == 2)
        {
            DesativarNevoa();
        }
    }

    public void DesativarNevoa()
    {
        animator.SetBool("Visivel", false);
    }

    public void AtivarNevoa()
    {
        animator.SetBool("Visivel", true);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lupa"))
        {
            qtdDeLuz++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lupa"))
        {
            qtdDeLuz--;
            AtivarNevoa();
        }

    }

    public void AtivarColisor()
    {
        collider2d.isTrigger = false; 
    }

    public void DesativarColisor()
    {
        collider2d.isTrigger = true;
    }

}
