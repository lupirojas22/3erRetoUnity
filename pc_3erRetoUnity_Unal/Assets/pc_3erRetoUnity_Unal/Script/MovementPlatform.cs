using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlatform : MonoBehaviour
{
    public Vector3 puntoA; // es un vector para poner cordenadas  de donde va allegar
    public Vector3 puntoB; // es un vector para poner cordenadas  de donde arranca
    public float velocidad = 2.0f; // velocidad con la que se mueve
    public float tiempoDeEspera = 2.0f; // tiempo que se demora en volver a empezar

    private Vector3 destino;
    private bool yendoHaciaB = true;

    void Start()
    {
        destino = puntoB; 
        StartCoroutine(MoverObjeto());
    }

    IEnumerator MoverObjeto()
    {
        while (true)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);

            if (transform.position == destino)
            {
                if (yendoHaciaB)
                {
                    destino = puntoA; 
                }
                else
                {
                    destino = puntoB; 
                }
                yendoHaciaB = !yendoHaciaB;

                yield return new WaitForSeconds(tiempoDeEspera);
            }

            yield return null;
        }
    }
}
