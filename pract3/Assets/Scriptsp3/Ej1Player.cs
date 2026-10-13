
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] // Asegura que el GameObject tenga un Rigidbody.
public class Ej1Player : MonoBehaviour
{
    // Velocidad de movimiento del jugador en unidades por segundo.
    [SerializeField, Min(0f)]
    private float speed = 5f;

    // Referencia al componente Rigidbody del jugador.
    private Rigidbody rb;
    private Vector3 inputDirection;

    private void Awake()
    {
        // Obtiene la referencia al Rigidbody del jugador.
        rb = GetComponent<Rigidbody>();

        // Congela la rotación del Rigidbody para que no gire al recibir impactos.
        rb.constraints |= RigidbodyConstraints.FreezeRotation; 

        // Habilita la interpolación para suavizar el movimiento del Rigidbody.
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    private void Update()
    {
        // Obtiene la entrada del jugador para el movimiento horizontal y vertical.
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Calcula la dirección de entrada y la normaliza para que tenga una magnitud máxima de 1 para evitar velocidades diagonales excesivas.
        inputDirection = Vector3.ClampMagnitude(
            new Vector3(horizontal, 0f, vertical),
            1f
        );
    }

    private void FixedUpdate()
    {
        // Obtiene la velocidad actual del Rigidbody.
        Vector3 velocity = rb.linearVelocity;

        velocity.x = inputDirection.x * speed;
        velocity.z = inputDirection.z * speed;

        // Aplica la velocidad calculada al Rigidbody para mover al jugador.
        rb.linearVelocity = velocity;
    }
}