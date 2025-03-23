using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverFondo : MonoBehaviour
{

    public float scrollSpeed = 0.5f;
    [SerializeField] private MeshRenderer mesh;

    void Start()
    {}

    void Update()
    {
        Vector2 offset = new Vector2(-Time.time * scrollSpeed, Time.time * scrollSpeed);
        mesh.material.mainTextureOffset = offset;
    }
}
