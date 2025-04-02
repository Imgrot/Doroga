using UnityEngine;

public class AutoDestruir : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.4f);
    }
}