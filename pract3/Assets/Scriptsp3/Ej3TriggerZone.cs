
using UnityEngine;

// Clase para aplicar efectos a un jugador al entrar en una zona de activación.
public class Ej3TriggerZone : MonoBehaviour
{
    // Tipos de efectos que se pueden aplicar al jugador.
    public enum EffectMode
    {
        ChangeColor,
        ChangeLightIntensity,
        AddDamage
    }

    // Modo de efecto que se aplicará al jugador al entrar en la zona.
    [SerializeField]
    private EffectMode effectMode = EffectMode.ChangeColor;

    // Efectos visuales y de daño que se aplicarán según el modo seleccionado.
    [Header("Efecto de color")]
    [SerializeField]
    private Renderer targetRenderer;

    // Color que se aplicará al objeto al entrar en la zona.
    [SerializeField]
    private Color activeColor = Color.green;

    // Intensidad de luz que se aplicará al objeto al entrar en la zona.
    [Header("Efecto de luz")]
    [SerializeField]
    private Light targetLight;

    [SerializeField, Min(0f)]
    private float activeLightIntensity = 3f;

    // Cantidad de daño que se aplicará al jugador al entrar en la zona.
    [Header("Efecto de daño")]
    [SerializeField, Min(0)]
    private int damageIncrease = 10;

    private Color originalColor;
    private float originalLightIntensity;

    // Inicializa los valores originales de color e intensidad de luz al iniciar el juego.
    private void Awake()
    {
        if (targetRenderer != null)
        {
            originalColor = targetRenderer.material.color;
        }

        if (targetLight != null)
        {
            originalLightIntensity = targetLight.intensity;
        }
    }

    // Se llama cuando un objeto entra en la zona de activación.
    private void OnTriggerEnter(Collider other)
    {
        // Intenta obtener el componente Ej3PlayerStatus del objeto que entró en la zona.
        Ej3PlayerStatus player =
            other.GetComponentInParent<Ej3PlayerStatus>();

        // Si no se encuentra un Ej3PlayerStatus, no se aplica ningún efecto.
        if (player == null)
        {
            return;
        }

        // Aplica el efecto correspondiente según el modo seleccionado.
        switch (effectMode)
        {
            case EffectMode.ChangeColor:
                if (targetRenderer != null)
                {
                    // Cambia el color del material del Renderer al color activo.
                    targetRenderer.material.color = activeColor;
                }
                break;

            case EffectMode.ChangeLightIntensity:
                if (targetLight != null)
                {
                    // Cambia la intensidad de la luz al valor activo.
                    targetLight.intensity = activeLightIntensity;
                }
                break;

            case EffectMode.AddDamage:
                // Aumenta el daño acumulado del jugador en la cantidad especificada.
                player.AddDamage(damageIncrease);
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Intenta obtener el componente Ej3PlayerStatus del objeto que salió de la zona.
        if (other.GetComponentInParent<Ej3PlayerStatus>() == null)
        {
            return;
        }

        // Restaura los valores originales de color e intensidad de luz al salir de la zona.
        switch (effectMode)
        {
            case EffectMode.ChangeColor:
                if (targetRenderer != null)
                {
                    targetRenderer.material.color = originalColor;
                }
                break;

            case EffectMode.ChangeLightIntensity:
                if (targetLight != null)
                {
                    targetLight.intensity = originalLightIntensity;
                }
                break;
        }
    }
}