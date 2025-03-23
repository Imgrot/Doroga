using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class koyukiProyectile : MonoBehaviour
{
    public float koyukiSpeed = 15.0f;
    public float limiteIzquierdo = -12f;

    void Update()
    {
        transform.Translate(Vector3.up * koyukiSpeed * Time.deltaTime);

        if (transform.position.x < limiteIzquierdo)
        {
            Destroy(gameObject);
        }
    }
}
