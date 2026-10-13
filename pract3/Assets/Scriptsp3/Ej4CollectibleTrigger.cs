
using UnityEngine;

// Clase que contiene la lógica para detectar cuando un jugador recoge un objeto coleccionable.
public class Ej4CollectibleTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Intenta obtener el componente PlayerStatus del objeto que colisionó con el trigger.
        Ej3PlayerStatus player =
            other.GetComponentInParent<Ej3PlayerStatus>();

        if (player == null)
        {
            return;
        }

        // Notifica que el jugador ha recogido el objeto coleccionable.
        Debug.Log(
            $"{player.gameObject.name} ha recogido {gameObject.name}.",
            this
        );

        // Desactiva el objeto coleccionable para simular que ha sido recogido.
        gameObject.SetActive(false);
    }
}