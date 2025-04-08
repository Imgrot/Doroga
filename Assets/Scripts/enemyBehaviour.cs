using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    public float speedX = 5.0f;
    public float speedY = 2.0f;
    [SerializeField] private GameObject[] buffs;
    public GameObject explosionPrefab;

    private float direccionY;
    private float cambioTiempo;
    private float tiempoDesdeUltimoCambio;

    void Start()
    {
        direccionY = Random.Range(-1f, 1f);
        cambioTiempo = Random.Range(1f, 3f);
        tiempoDesdeUltimoCambio = 0f;
    }
    void Update()
    {
        MovimientoEnemigo();
    }
    public void MovimientoEnemigo()
    {
        transform.Translate(Vector3.right * speedX * Time.deltaTime);
        transform.Translate(Vector3.up * direccionY * speedY * Time.deltaTime);

        tiempoDesdeUltimoCambio += Time.deltaTime;
        if (tiempoDesdeUltimoCambio >= cambioTiempo)
        {
            direccionY = Random.Range(-1f, 1f);
            cambioTiempo = Random.Range(1f, 3f);
            tiempoDesdeUltimoCambio = 0f;
        }

        // Desplazamiento de Pantalla en el Eje Y
        if (transform.position.y > 5.0f)
        {
            transform.position = new Vector3(transform.position.x, -5.0f, 0);
        }
        else if (transform.position.y < -5.0f)
        {
            transform.position = new Vector3(transform.position.x, 5.0f, 0);
        }

        // Desplazamiento de Pantalla en el Eje X
        if (transform.position.x > 7.0f)
        {
            transform.position = new Vector3(-10.0f, transform.position.y, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            DropBuff();
            Destroy(collision.transform.gameObject);
            Instantiate
            (
                explosionPrefab,
                transform.position + new Vector3(0, 0),
                Quaternion.identity
            );
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Player")
        {
            inputs player = collision.GetComponent<inputs>();
            if (player != null)
            {
                player.Damage();
            }
            Instantiate
            (
                explosionPrefab,
                transform.position + new Vector3(0, 0),
                Quaternion.identity
            );
            Destroy(this.gameObject);
        }
    }
    private void DropBuff()
    {
        float probabilidad = Random.value;

        if (probabilidad <= 0.3f && buffs.Length > 0)
        {
            int indiceAleatorio = Random.Range(0, buffs.Length);
            GameObject buffSeleccionado = buffs[indiceAleatorio];

            Instantiate
            (
                buffSeleccionado,
                transform.position + new Vector3(0, 0),
                Quaternion.identity
            );
        }
    }
}