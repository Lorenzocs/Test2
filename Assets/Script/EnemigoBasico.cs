using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoBasico : MonoBehaviour
{
    public Transform jugador;
    public float vision;
    public float velocidad;

    public Vector3[] posiciones;
    public int index;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, jugador.position) < vision)
        {
            Vector3 direccionAlJugador = (jugador.position - transform.position).normalized;
            direccionAlJugador.y = 0;

            transform.position += direccionAlJugador * velocidad * Time.deltaTime;

        }
        else
        {
            Vector3 direccionAPosicion = (posiciones[index] - transform.position).normalized;
            direccionAPosicion.y = 0;

            transform.position += direccionAPosicion * velocidad * Time.deltaTime;
   
        }
    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, vision);

        foreach (var posicion in posiciones)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(posicion, 0.2f);
        }
    }
}
