using UnityEngine;
using UnityEngine.Audio;

public class ControladorMusica : MonoBehaviour
{
    public AudioClip[] musicas;
    AudioSource musicSource;

    private void Awake()
    {
        musicSource = GetComponent<AudioSource>();
        musicSource.clip = musicas[0];
        musicSource.Play();
    }

    public void Musica1()
    {
        musicSource.clip = musicas[1];
        musicSource.Play();
    }

    public void Musica2()
    {
        musicSource.clip = musicas[2];
        musicSource.Play();
    }

    public void Musica3()
    {
        musicSource.clip = musicas[3];
        musicSource.Play();
    }
}
