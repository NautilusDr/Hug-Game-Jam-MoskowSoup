using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IntroLight : MonoBehaviour
{

    Image Lights;
    private void Start()
    {
        Lights = GetComponent<Image>();
        StartCoroutine(LightItUp());
    }

    IEnumerator LightItUp()
    {
        yield return new WaitForSeconds(2);
        while (Lights.color.a >= .05)
        {
            Lights.color = new(Lights.color.r, Lights.color.g, Lights.color.g, Lights.color.a - .05f);
            yield return new WaitForSeconds(.1f);
        }
        Destroy(gameObject);
    }
}
