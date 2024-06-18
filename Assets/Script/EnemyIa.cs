using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIa : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public List<Transform> positions;
    public int currentPosition;
    public float visionRange;
    public float attackRange;
    public bool canSeePlayer;

    void Start()
    {
        player = FindObjectOfType<IaPlayer>().transform;
        StartCoroutine(Patrol());
    }

    // Update is called once per frame
    void Update()
    {
        canSeePlayer = CanSeePlayer();
    }
    public IEnumerator Patrol()
    {

        while (canSeePlayer == false)
        {
            agent.isStopped = false;
            agent.destination = positions[currentPosition].position;
            while (Vector3.Distance(transform.position, positions[currentPosition].position) > 1f)
            {

                if (canSeePlayer == true)
                {
                    StartCoroutine(ChasePlayer());
                    yield break;
                }
                yield return null;// continuo el while en el siguiente frame
            }

            currentPosition++;
            if (currentPosition >= positions.Count)
            {
                currentPosition = 0;
            }

            yield return new WaitForSeconds(2);
        }



        yield return null;
    }

    public IEnumerator ChasePlayer()
    {
        agent.isStopped = false;

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
    public IEnumerator Attack()
    {
        agent.isStopped = true;
        yield return new WaitForSeconds(1);
        agent.isStopped = false;

        if (canSeePlayer == true && Vector3.Distance(transform.position, player.position) <= attackRange)
        {
            StartCoroutine(Attack());
        }
        else if (canSeePlayer == true && Vector3.Distance(transform.position, player.position) > attackRange)
        {
            StartCoroutine(ChasePlayer());
        }
        else
        {
            StartCoroutine(Patrol());
        }


    }



    public bool CanSeePlayer()
    {
        if (Vector3.Distance(transform.position, player.position) < visionRange)
        {
            Vector3 directionToPlayer = (player.position - transform.position).normalized;

            float angle = Vector3.Angle(transform.forward, directionToPlayer);

            if (angle < 45f)
            {
                return true;
            }

        }

        return false;
    }


    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 leftSide = Quaternion.Euler(0, -45, 0) * transform.forward;
        Vector3 rightSide = Quaternion.Euler(0, 45, 0) * transform.forward;

        Gizmos.DrawRay(transform.position, leftSide * visionRange);
        Gizmos.DrawRay(transform.position, rightSide * visionRange);

        Gizmos.DrawWireSphere(transform.position, visionRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }


    public void OnDestroy()
    {
        StopAllCoroutines();
    }
}
