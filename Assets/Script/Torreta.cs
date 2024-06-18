using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    public Transform parteGirable;
    public GameObject bullet;
    public float velocidadDeGiro = 30f;
    public float rangoDeAccion;
    public LayerMask capasDetectables;
    public Transform puntoDeDisparo;
    public float timeToShoot;
    private Transform jugador;
    private float _counter;
    void Start()
    {
        jugador = FindObjectOfType<Player>().transform;
    }

    void Update()
    {
        _counter += Time.deltaTime;
        bool playerInRange = Vector3.Distance(jugador.position, transform.position) <= rangoDeAccion;

        if (playerInRange == true)
        {
            print("Player in range");
            Vector3 direccionAJugador = (jugador.position - transform.position).normalized;
            direccionAJugador.y = 0;

            Debug.DrawRay(transform.position, direccionAJugador * rangoDeAccion, Color.red);
            
            if (Physics.Raycast(transform.position, direccionAJugador, out RaycastHit hit , rangoDeAccion, capasDetectables))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    print("TeVeo");
                    ApuntarHaciaJugador();
                }
                else
                {
                    print("No te veo");
                    GirarConstantemente();
                }

            }

        }
        else
        {
            print("Player out of range");
            GirarConstantemente();
        }
    }
    void ApuntarHaciaJugador()
    {
        /* Vector3 direccion = jugador.position - parteGirable.position;
         direccion.y = 0; // Ignora la diferencia de altura para que la rotación sea solo horizontal
        */
        Vector3 direccionAlJugador = ((jugador.position + Vector3.up) - parteGirable.position).normalized;
        direccionAlJugador.y = 0;

        Quaternion rotacionDeseada = Quaternion.LookRotation(direccionAlJugador);
        parteGirable.rotation = Quaternion.RotateTowards(parteGirable.rotation, rotacionDeseada, velocidadDeGiro * Time.deltaTime);

        Debug.DrawRay(puntoDeDisparo.position, puntoDeDisparo.forward * rangoDeAccion, Color.green);

        if (Physics.Raycast(puntoDeDisparo.position, puntoDeDisparo.forward, out RaycastHit hit, rangoDeAccion, capasDetectables))
        {
            if (hit.transform.CompareTag("Player"))
            {
                print("Te disparo");
                Disparar();
            }
        }
    }

    void Disparar()
    {
        if (_counter >= timeToShoot)
        {
            _counter = 0;
            Instantiate(bullet, puntoDeDisparo.position, puntoDeDisparo.rotation);
            Debug.Log("Disparando al jugador!");

        }
    }
    void GirarConstantemente()
    {
        parteGirable.Rotate(0, velocidadDeGiro * Time.deltaTime, 0);
    }

    void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeAccion);
    }
}