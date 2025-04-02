using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class unstanciateTriple : MonoBehaviour
{
    public float limiteIzquierdo = -12f;
    public float koyukiSpeed = 15.0f;

    void Update()
    {
        transform.Translate(Vector3.up * koyukiSpeed * Time.deltaTime);
        if (transform.position.x < limiteIzquierdo)
        {
            Destroy(gameObject);
        }
    }
}
