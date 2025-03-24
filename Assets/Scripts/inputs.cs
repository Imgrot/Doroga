using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class inputs : MonoBehaviour
{
    public float speedX = 5.0f;
    public float speedY = 4.0f;
    public GameObject koyukiProyectile;

    float cooldownDisparo = 0.4f;
    float cooldownActual = 0.0f;

    public AudioSource audioSource;
    public AudioClip sonidoDisparo;
    public AudioClip sonidoDisparo2;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        MovimientoDoro();
        InstanciarKoyuki();
    }

    public void MovimientoDoro()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speedX * movimientoHorizontal * Time.deltaTime);

        float movimientoVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * speedY * movimientoVertical * Time.deltaTime);

        // Limites Verticales
        if (transform.position.y > 4.3f)
        {
            transform.position = new Vector3(transform.position.x, 4.3f, 0);
        }
        else if (transform.position.y < -4.3f)
        {
            transform.position = new Vector3(transform.position.x, -4.3f, 0);
        }

        // Limites Horizontales
        if (transform.position.x > 10.5f)
        {
            transform.position = new Vector3(10.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -10.5f)
        {
            transform.position = new Vector3(-10.5f, transform.position.y, 0);
        }

        // Desplazamiento de Pantalla
        // if(transform.position.x > 11f)
        // {
        //     transform.position = new Vector3(-11f, transform.position.y, 0);
        // }
        // else if(transform.position.x < -11f)
        // {
        //     transform.position = new Vector3(11f, transform.position.y, 0);
        // }
    }

    public void InstanciarKoyuki()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if (Time.time > cooldownActual)
            {
                Disparar();
                cooldownActual = Time.time + cooldownDisparo;
            }
        }
    }

    public void Disparar()
    {
        Instantiate(
            koyukiProyectile,
            transform.position + new Vector3(-1.0f, 0),
            Quaternion.Euler(0, 0, 90)
        );
        if (audioSource != null && sonidoDisparo != null)
        {
            audioSource.PlayOneShot(sonidoDisparo2);
            audioSource.PlayOneShot(sonidoDisparo);
        }
    }
}