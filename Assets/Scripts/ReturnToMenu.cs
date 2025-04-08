using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    private bool puedeDetectar = false;

    void Start()
    {
        transform.position = new Vector3(-1.5f, 0, 0);
        Invoke("ActivarDeteccion", 2f);
    }

    void ActivarDeteccion()
    {
        puedeDetectar = true;
    }

    void Update()
    {
        if (puedeDetectar && Input.anyKeyDown)
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
