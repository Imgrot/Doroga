using System.Collections;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public Transform spawnPoint;
    public float spawnHeightMin = -4f;
    public float spawnHeightMax = 4f;

    public int nivelActual = 1;
    public int oleadasPorNivel = 5;
    public int enemigosBasePorOleada = 3;
    public float tiempoEntreOleadas = 5f;
    public float tiempoEntreEnemigos = 0.5f;

    private int oleadaActual = 0;
    private bool nivelEnCurso = true;

    void Start()
    {
        StartCoroutine(IniciarOleadas());
    }

    IEnumerator IniciarOleadas()
    {
        while (nivelEnCurso)
        {
            oleadaActual++;

            int enemigosEnEstaOleada = enemigosBasePorOleada + (nivelActual * 2);

            yield return StartCoroutine(SpawnOleada(enemigosEnEstaOleada));

            if (oleadaActual >= oleadasPorNivel)
            {
                TerminarNivel();
                yield break;
            }

            yield return new WaitForSeconds(tiempoEntreOleadas);
        }
    }

    IEnumerator SpawnOleada(int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(tiempoEntreEnemigos);
        }
    }

    void SpawnEnemy()
    {
        float randomY = Random.Range(spawnHeightMin, spawnHeightMax);
        Vector3 spawnPosition = new Vector3(spawnPoint.position.x, randomY, 0);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    void TerminarNivel()
    {
        Debug.Log("Nivel completado: " + nivelActual);
        nivelEnCurso = false;
    }
}
