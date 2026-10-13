
using UnityEngine;

public class Ej2CollisionColor : MonoBehaviour
{
    // Color que se aplicará al objeto al colisionar.
    [SerializeField]
    private Color collisionColor = Color.red;

    // Indica si también se debe cambiar el color del otro objeto con el que se colisiona.
    [SerializeField]
    private bool changeOtherObjectToo;

    // Se llama cuando el GameObject colisiona con otro.
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(
            $"{gameObject.name} ha colisionado con {collision.gameObject.name}.",
            this
        );

        // Cambia el color del objeto que colisiona.
        SetColor(GetComponent<Renderer>(), collisionColor);

        // Cambia el color del otro objeto si la opción está habilitada.
        if (changeOtherObjectToo)
        {
            SetColor(
                // Obtiene el Renderer del otro objeto y cambia su color.
                collision.gameObject.GetComponent<Renderer>(),
                collisionColor
            );
        }
    }

    // Cambia el color del material del Renderer especificado.
    private static void SetColor(Renderer targetRenderer, Color color)
    {
        // Verifica si el Renderer no es nulo antes de intentar cambiar el color.
        if (targetRenderer != null)
        {
            targetRenderer.material.color = color;
        }
    }
}