using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemigos;

    public float variacionY = 0.5f;

    void Start()
    {
        ProgramarSiguienteSpawn();
    }

    private void ProgramarSiguienteSpawn()
    {
        float tiempoAleatorio = Random.Range(0.5f, 2.0f);
        Invoke("EnemigoInstanciado", tiempoAleatorio);
    }

    private void EnemigoInstanciado()
    {
        if (enemigos.Length == 0) return;

        float probabilidad = Random.value;

        if (probabilidad <= 0.3f)
        {
            int indiceAleatorio = Random.Range(0, enemigos.Length);
            GameObject enemigoSeleccionado = enemigos[indiceAleatorio];

            float posicionY = transform.position.y + Random.Range(-variacionY, variacionY);
            Vector3 posicionSpawn = new Vector3(transform.position.x, posicionY, 0);

            Instantiate(enemigoSeleccionado, posicionSpawn, Quaternion.identity);
        }

        ProgramarSiguienteSpawn();
    }
}
