using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class patrol : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    int waypointindex;
    
    Vector3 target;

    void Awake() 
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
            
    }
    // Start is called before the first frame update
    void Start()
    {
        updateDestination();
    }

    // Update is called once per frame
    void Update()
    {
       if (Vector3.Distance(transform.position, target) < 1)
       {
           iteratewaypointindex();
           updateDestination();

       } 
    }

    void updateDestination()
    {
        target = waypoints[waypointindex].position;
        navMeshAgent.SetDestination(target);
    }

    void iteratewaypointindex()
    {
        waypointindex++;
        if (waypointindex == waypoints.Length)
        {
            waypointindex = 0;
        }
    }
}
