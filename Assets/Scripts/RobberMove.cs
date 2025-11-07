using UnityEngine;

public class RobberMove : MonoBehaviour
{
    // Controla el movimiento de los enemigos dentro del mundo

    public GameObject chaser; // Object que persigue a los enemigos, en este caso el jugador
    public float speed = 5f; // Velocidad de movimiento
    public float belowGroundResetHeight = -5f; // Altura a la que se resetea la posición del enemigo

    Vector3 startPosition;
    Vector3 direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Guardamos la posición inicial del enemigo instanciado
        startPosition = transform.position;
    }

    void LateUpdate()
    {
        // Obtiene la dirección del jugador (chaser)
        direction = chaser.transform.position - this.transform.position;

        // Orienta el personaje en la dirección contraria al jugador
        Vector3 lookAwayPoint = this.transform.position - direction;
        this.transform.LookAt(lookAwayPoint);
       
        // Mover el enemigo alejandolo del jugador
        Vector3 velocity = -direction.normalized * speed * Time.deltaTime;
        this.transform.position += velocity;

        // Si el enemigo se cae de la plataforma se resetea la posición inicial
        if (transform.position.y < belowGroundResetHeight)
        {
            transform.position = startPosition;
        }

    }
}
