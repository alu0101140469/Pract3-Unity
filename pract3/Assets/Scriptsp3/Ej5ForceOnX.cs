
using UnityEngine;

// Clase que aplica una fuerza de impulso a un objeto en la dirección especificada cuando se presiona la tecla X.
[RequireComponent(typeof(Rigidbody))]
public class Ej5ForceOnX : MonoBehaviour
{
    // Dirección en la que se aplicará la fuerza de impulso.
    [SerializeField]
    private Vector3 launchDirection = new Vector3(1f, 0.5f, 0f);

    // Magnitud de la fuerza de impulso que se aplicará al objeto.
    [SerializeField, Min(0f)]
    private float impulse = 8f;

    // Referencia al componente Rigidbody del objeto al que se aplicará la fuerza.
    private Rigidbody rb;
    private bool launchRequested;

    // Inicializa la referencia al componente Rigidbody al inicio del juego.
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Actualiza el estado de la solicitud de lanzamiento cuando se presiona la tecla X.
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            launchRequested = true;
        }
    }

    // Aplica la fuerza de impulso al objeto en la dirección especificada si se ha solicitado el lanzamiento.
    private void FixedUpdate()
    {
        if (!launchRequested)
        {
            return;
        }

        // Resetea la solicitud de lanzamiento para evitar aplicar la fuerza en el siguiente FixedUpdate.
        launchRequested = false;

        // Aplica la fuerza de impulso solo si el Rigidbody no es cinemático y la dirección de lanzamiento tiene una magnitud mayor que cero.
        if (!rb.isKinematic && launchDirection.sqrMagnitude > 0f)
        {
            rb.AddForce(
                launchDirection.normalized * impulse,
                ForceMode.Impulse
            );
        }
    }
}