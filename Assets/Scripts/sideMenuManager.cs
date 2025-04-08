using UnityEngine;
using UnityEngine.UI;

public class sideMenuManager : MonoBehaviour
{
    public inputs jugador;

    public Text vidasText;

    public GameObject GameOverDoro;
    public Image iconoEscudo;
    public Image iconoDisparoTriple;
    public Image iconoDisparoRapido;
    public Image iconoVelocidad;

    private bool gameOverMostrado = false;

    void Update()
    {
        if (jugador != null)
        {
            if (jugador.vidas == 0)
            {
                vidasText.text = "X 0";
                if (!gameOverMostrado)
                {
                    iconoEscudo.enabled = false;
                    iconoDisparoTriple.enabled = false;
                    iconoDisparoRapido.enabled = false;
                    iconoVelocidad.enabled = false;
                    Instantiate(
                        GameOverDoro,
                        transform.position,
                        Quaternion.identity
                    );
                    gameOverMostrado = true;
                }
            }
            else
            {
                vidasText.text = "X " + jugador.vidas;
            }

            iconoEscudo.enabled = jugador.shieldOn;
            iconoDisparoTriple.enabled = jugador.disparoTriple;
            iconoDisparoRapido.enabled = jugador.cooldownDisparo < 0.4f;
            iconoVelocidad.enabled = jugador.speedBuffOn;
        }
    }
}
