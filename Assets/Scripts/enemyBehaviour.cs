using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    public float speedX = 5.0f;
    public float speedY = 4.0f;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }
    void Update()
    {
        MovimientoEnemigo();
    }
    public void MovimientoEnemigo()
    {

        float movimientoAleatorioEjeX = Random.Range(-5.0f, 5.0f);
        float movimientoAleatorioEjeY = Random.Range(-5.0f, 5.0f);

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
        if (collision.name == "Laser")
        {
            Destroy(this.gameObject);
        }
    }
}
