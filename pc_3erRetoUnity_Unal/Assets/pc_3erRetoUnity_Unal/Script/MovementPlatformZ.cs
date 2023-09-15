using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlatformZ : MonoBehaviour
{
    public float distanciaMaxima = 5.0f;   // Distancia máxima en el eje Z
    public float velocidad = 2.0f;         // Velocidad de movimiento
    public float tiempoDeEspera = 2.0f;    // Tiempo de espera antes de cambiar de dirección

    private Vector3 puntoA;
    private Vector3 puntoB;
    private bool yendoHaciaB = true;

    void Start()
    {
        puntoA = transform.position;
        puntoB = new Vector3(transform.position.x, transform.position.y, transform.position.z + distanciaMaxima);
        StartCoroutine(MoverObjeto());
    }

    IEnumerator MoverObjeto()
    {
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, yendoHaciaB ? puntoB : puntoA, velocidad * Time.deltaTime);
            if (transform.position == (yendoHaciaB ? puntoB : puntoA))
            {
                yendoHaciaB = !yendoHaciaB;
                yield return new WaitForSeconds(tiempoDeEspera);
            }

            yield return null;
        }
    }
}
