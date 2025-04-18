using UnityEngine;

public class powerUpBehaviour : MonoBehaviour
{
    public float speedX = 5.0f;
    public int PowerUpId = 0;

    void Start()
    {
    }
    void Update()
    {
        transform.Translate(Vector3.right * speedX * Time.deltaTime);
        if (transform.position.x > 7.0f)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            inputs player = collision.GetComponent<inputs>();
            if (player != null)
            {
                if (PowerUpId == 0)          //DORO SANTA
                {
                    player.koyukiTripleOn();
                }
                else if (PowerUpId == 1)     //REISA
                {
                    player.koyukiSpeedOn();
                }
                else if (PowerUpId == 2)     //HARE
                {
                    player.doroSpeedOn();
                }
                else if (PowerUpId == 4)     //DORO HOLD
                {
                    player.activarEscudo();
                }
            }
            Destroy(this.gameObject);
        }
    }
}
