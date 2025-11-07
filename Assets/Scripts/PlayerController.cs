using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Sirve para controlar al personaje dentro del mundo

    public float movementSpeed = 10.0f;
    public float rotationSpeed = 300.0f;
    public float belowGroundResetHeight = -5f;

    Vector3 startPosition;

    void Start()
    {
        // Guardamos nuestra posición inicial
        startPosition = transform.position;
    }

    void Update()
    {
        // Obtiene el input del eje vertical. Flechas arriba y abajo para el movimiento hacia adelante y atrás
        float verticalMovement = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        // Obtiene el input del eje horizontal. Flechas izquierda y derecha para la rotación.
        float rotationalMovement = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        // Mover el jugador según las entradas del teclado
        transform.Translate(0, 0, verticalMovement);
        transform.Rotate(0, rotationalMovement, 0);

        // Si el jugador se de la plataforma resetear a posición inicial
        if (transform.position.y < belowGroundResetHeight) {
            transform.position = startPosition;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Destruye los enemigos cuando son pillados
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }


}
