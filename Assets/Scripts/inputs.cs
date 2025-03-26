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
    public GameObject koyukiProyectileTriple;
    public bool disparoTriple = false;
    public bool speedBuffOn = false;
    public bool koyukiExplosiva = false;

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
        float movimientoVertical = Input.GetAxis("Vertical");
        if (speedBuffOn)
        {
            transform.Translate(Vector3.right * speedX * 2 * movimientoHorizontal * Time.deltaTime);
            transform.Translate(Vector3.up * speedY * 2 * movimientoVertical * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * speedX * movimientoHorizontal * Time.deltaTime);
            transform.Translate(Vector3.up * speedY * movimientoVertical * Time.deltaTime);
        }

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
        if (disparoTriple)
        {
            if (koyukiExplosiva)
            {
                // CREAR KOYUKI EXPLOSIVA TRIPLE
                Instantiate(
                    koyukiProyectileTriple,
                    transform.position + new Vector3(0, 0),
                    Quaternion.Euler(0, 0, 90)
                );
                koyukiExplosiva = false;
            }
            else
            {
                Instantiate(
                    koyukiProyectileTriple,
                    transform.position + new Vector3(0, 0),
                    Quaternion.Euler(0, 0, 90)
                );
            }
        }
        else
        {
            if (koyukiExplosiva)
            {
                // CREAR KOYUKI EXPLOSIVA
                Instantiate(
                    koyukiProyectile,
                    transform.position + new Vector3(0, 0),
                    Quaternion.Euler(0, 0, 90)
                );
                koyukiExplosiva = false;
            }
            else
            {
                Instantiate(
                    koyukiProyectile,
                    transform.position + new Vector3(0, 0),
                    Quaternion.Euler(0, 0, 90)
                );
            }
        }
        // Instantiate(
        //     koyukiProyectile,
        //     transform.position + new Vector3(-1.0f, 0),
        //     Quaternion.Euler(0, 0, 90)
        // );
        if (audioSource != null && sonidoDisparo != null && sonidoDisparo2 != null)
        {
            audioSource.PlayOneShot(sonidoDisparo2);
            audioSource.PlayOneShot(sonidoDisparo);
        }
    }
    public void koyukiTripleOn()
    {
        disparoTriple = true;
        StartCoroutine(DisparoTriple());
    }
    public void koyukiSpeedOn()
    {
        cooldownDisparo = 0.2f;
        StartCoroutine(DisparoSpeed());
    }
    public void doroSpeedOn()
    {
        speedBuffOn = true;
        StartCoroutine(DoroSpeed());
    }
    public void koyukiExplosivaOn()
    {
        koyukiExplosiva = true;
    }
    public IEnumerator DisparoTriple()
    {
        yield return new WaitForSeconds(5.0f);
        disparoTriple = false;
    }
    public IEnumerator DisparoSpeed()
    {
        yield return new WaitForSeconds(5.0f);
        cooldownDisparo = 0.4f;
    }
    public IEnumerator DoroSpeed()
    {
        yield return new WaitForSeconds(5.0f);
        speedBuffOn = false;
    }
}