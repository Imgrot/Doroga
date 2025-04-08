using UnityEngine;

public class vidaMusicManager : MonoBehaviour
{
    public inputs jugador;
    public AudioSource audioSource;
    public AudioClip musicaVivo;
    public AudioClip musicaGameOver;

    private bool musicaGameOverReproducida = false;
    private bool musicaVivoReproducida = false;

    void Update()
    {
        if (jugador == null || audioSource == null) return;

        if (jugador.vidas > 0)
        {
            if (!musicaVivoReproducida)
            {
                audioSource.clip = musicaVivo;
                audioSource.loop = true;
                audioSource.Play();
                musicaVivoReproducida = true;
                musicaGameOverReproducida = false;
            }
        }
        else // vidas == 0
        {
            if (!musicaGameOverReproducida)
            {
                audioSource.clip = musicaGameOver;
                audioSource.loop = false;
                audioSource.Play();
                musicaGameOverReproducida = true;
                musicaVivoReproducida = false;
            }
        }
    }
}
