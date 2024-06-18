using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Test : MonoBehaviour
{
    public List<Transform> posiciones;//[ 0,1,2,3,4,5 ]
    public NavMeshAgent agent;
    public bool canSeePlayer;
    public float attackRange = 1.5f;
    public int currentPosition;
    public float visionRange = 5.0f;
    public Transform player;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Patrol());
    }

    public void Update()
    {
        canSeePlayer = CanSeePlayer();
    }


    IEnumerator Patrol()
    {
        while (canSeePlayer == false)//si no estoy viendo al player
        {
            // voy a un punto
            agent.destination = posiciones[currentPosition].position;

            // Espera hasta que el agente llegue al destino.
            while (Vector3.Distance(transform.position, posiciones[currentPosition].position) > 0.5f)//cuando llego salgo del while
            {
                if (canSeePlayer == true)
                {
                    StartCoroutine(ChasePlayer());
                    yield break;  // Sale de la corutina
                }
                print("Estoy caminando");
                yield return null;  // Continúa en el próximo frame.
            }


            currentPosition++;
            if (currentPosition >= posiciones.Count)
            {
                currentPosition = 0;
            }
            // currentPosition = (currentPosition + 1) % posiciones.Count;
            yield return new WaitForSeconds(2);  // Espera antes de moverse al siguiente punto
        }
    }

    IEnumerator ChasePlayer()
    {
        //mientras la distancia es mayor a mi rango de ataque, sigo al player
        while (Vector3.Distance(transform.position, player.position) > attackRange)
        {
            if (canSeePlayer == false)
            {
                StartCoroutine(Patrol());
                yield break;
            }

            agent.destination = player.position;
            yield return null;
        }

        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        agent.isStopped = true; // Detener el NavMeshAgent mientras ataca
        Debug.Log("Atacando al jugador!");

        yield return new WaitForSeconds(1); // Simula la duración del ataque

        agent.isStopped = false;

        // si no estoy en rango de ataque, sigo al player..
        if (canSeePlayer == true && Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            StartCoroutine(ChasePlayer());
        }
        else
        {
            // si lo pierdo de vista
            canSeePlayer = false;
            StartCoroutine(Patrol());
        }
    }

    bool CanSeePlayer()
    {
        //si la distancia al player es menor al rango de vision
        if (Vector3.Distance(transform.position, player.position) < visionRange)
        {
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            //retorna un angulo positivo entre dos puntos
            float angle = Vector3.Angle(transform.forward, directionToPlayer);
            if (angle < 45.0f) // Campo de visión de 90 grados
            {
                print("Entro aca");
                return true;
            }
        }
        print("Salgo aca");
        return false;
    }


    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRange);

        DrawFieldOfView(45);
    }
    void DrawFieldOfView(float viewAngle)
    {
        Gizmos.color = Color.red;
        //calculo el lado izquierdo
        Vector3 leftSide = Quaternion.Euler(0, -viewAngle, 0) * transform.forward;
        //calculo lado derecho
        Vector3 rightSide = Quaternion.Euler(0, viewAngle, 0) * transform.forward;

        // Dibuja los límites del campo de visión
        Gizmos.DrawRay(transform.position, leftSide * visionRange);
        Gizmos.DrawRay(transform.position, rightSide * visionRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, visionRange);
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, attackRange);


    }

}