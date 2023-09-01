using UnityEngine;

public class VerticalPlatformMovement : MonoBehaviour
{
    public float speed = 2.0f;       // Velocidad de movimiento
    public float distance = 5.0f;    // Distancia vertical

    private Vector3 initialPosition;
    private float movement;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Calcula el desplazamiento vertical usando Mathf.PingPong
        movement = Mathf.PingPong(Time.time * speed, distance);

        // Actualiza la posición de la plataforma en el eje Y
        transform.position = initialPosition + Vector3.up * movement;
    }
}
