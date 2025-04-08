using UnityEngine;

public class buffSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] buffs;
    public float variacionY = 4.0f;

    void Start()
    {
        ProgramarSiguienteSpawn();
    }

    private void ProgramarSiguienteSpawn()
    {
        Invoke("DropBuff", 10f);

    }

    private void DropBuff()
    {
        int indiceAleatorio = Random.Range(0, buffs.Length);
        GameObject buffSeleccionado = buffs[indiceAleatorio];

        float posicionY = transform.position.y + Random.Range(-variacionY, variacionY);
        Vector3 posicionSpawn = new Vector3(transform.position.x, posicionY, 0);
        Instantiate
        (
            buffSeleccionado,
            posicionSpawn,
            Quaternion.identity
        );
        ProgramarSiguienteSpawn();
    }
}
