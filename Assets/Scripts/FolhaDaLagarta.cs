using UnityEngine;

public class FolhaDaLagarta : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Larva"))
        {
            Destroy(gameObject);
        }
    }
}
