
using UnityEngine;

// Clase que representa el estado del jugador, incluyendo el daño acumulado.
public class Ej3PlayerStatus : MonoBehaviour
{
    // Cantidad de daño acumulado por el jugador.
    [SerializeField, Min(0)]
    private int damage;

    // Propiedad pública para acceder al daño acumulado.
    public int Damage => damage;

    // Método para agregar daño al jugador. 
    public void AddDamage(int amount)
    {
        // Si la cantidad de daño es menor o igual a cero, no se realiza ninguna acción.
        if (amount <= 0)
        {
            return;
        }

        // Agrega la cantidad de daño especificada al daño acumulado.
        damage += amount;

        // Registra en la consola el daño acumulado después de agregar el nuevo daño.
        Debug.Log(
            $"{gameObject.name}: daño acumulado = {damage}.",
            this
        );
    }
}