using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IaPlayer : MonoBehaviour
{
    public Camera camera;
    public NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                print(hit.transform.gameObject.name);

                agent.SetDestination(hit.point);
                // agent.destination= hit.point;
            }
        }
      
    }


}
