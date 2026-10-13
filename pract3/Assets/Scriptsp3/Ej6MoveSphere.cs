
using UnityEngine;

// Clase que mueve una esfera hacia un objetivo y cambia el material de un obstáculo cuando se detecta una colisión.
public class Ej6MoveSphere : MonoBehaviour
{
    // Referencias a los objetos de la escena y sus componentes.
    [Header("Referencias de la escena")]
    [SerializeField]
    private Transform target;

    // Referencias a los colliders y al Renderer del obstáculo.
    [SerializeField]
    private SphereCollider movingSphereCollider;

    // Referencias al collider del obstáculo, al Renderer y al material que se aplicará cuando la esfera colisione con el obstáculo.
    [SerializeField]
    private Collider obstacleCollider;

    [SerializeField]
    private Renderer obstacleRenderer;

    [SerializeField]
    private Material obstacleHitMaterial;

    // Velocidad a la que se moverá la esfera hacia el objetivo.
    [Header("Movimiento")]
    [SerializeField, Min(0f)]
    private float speed = 2f;

    // Indicar si el material del obstáculo ha sido cambiado después de la colisión.
    private bool obstacleChanged;

    // Inicializa las referencias a los componentes y verifica que estén asignados correctamente.
    private void Awake()
    {
        // Si no se ha asignado el SphereCollider de la esfera en el Inspector, intenta obtenerlo automáticamente.
        if (movingSphereCollider == null)
        {
            movingSphereCollider = GetComponent<SphereCollider>();
        }

        // Verifica que todas las referencias necesarias estén asignadas en el Inspector.
        if (target == null ||
            movingSphereCollider == null ||
            obstacleCollider == null ||
            obstacleRenderer == null ||
            obstacleHitMaterial == null)
        {
            // Si alguna referencia no está asignada, muestra un mensaje de error.
            Debug.LogError(
                "MoveSphereToGoal: asigna el objetivo, los colliders, " +
                "el Renderer y el material en el Inspector.",
                this
            );

            enabled = false;
        }
    }

    // Actualiza la posición de la esfera hacia el objetivo y verifica la colisión con el obstáculo.
    private void Update()
    {
        // Desplaza la esfera hacia el objetivo.
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        // Si el material del obstáculo ya ha sido cambiado, no se realiza ninguna acción adicional.
        if (!obstacleChanged &&
            Physics.ComputePenetration(
                movingSphereCollider,
                movingSphereCollider.transform.position,
                movingSphereCollider.transform.rotation,
                obstacleCollider,
                obstacleCollider.transform.position,
                obstacleCollider.transform.rotation,
                out _,
                out _
            ))
        {
            // Cambia el material del obstáculo al material especificado cuando se detecta la colisión.
            obstacleRenderer.material = obstacleHitMaterial;
            obstacleChanged = true;

            // Registra en la consola que la esfera ha alcanzado el obstáculo.
            Debug.Log(
                $"{gameObject.name} ha alcanzado el obstáculo " +
                $"{obstacleCollider.gameObject.name}.",
                this
            );
        }
    }
}