using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    public float speedX = 5.0f;
    public float speedY = 4.0f;
    [SerializeField] private GameObject[] buffs;
    public GameObject explosionPrefab;

    void Start()
    {
    }
    void Update()
    {
        MovimientoEnemigo();
    }
    public void MovimientoEnemigo()
    {
        transform.Translate(Vector3.right * speedX * Time.deltaTime);

        // Limites Verticales
        if (transform.position.y > 5.0f)
        {
            transform.position = new Vector3(transform.position.x, -5.0f, 0);
        }
        else if (transform.position.y < -5.0f)
        {
            transform.position = new Vector3(transform.position.x, 5.0f, 0);
        }

        // Desplazamiento de Pantalla
        if (transform.position.x > 13.0f)
        {
            transform.position = new Vector3(-13.0f, transform.position.y, 0);
        }
        else if (transform.position.x < -13.0f)
        {
            transform.position = new Vector3(13.0f, transform.position.y, 0);
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