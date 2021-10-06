using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Actor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject goal;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (navMeshAgent != null)
            navMeshAgent.destination = goal.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        navMeshAgent.destination = goal.transform.position;
    }
}
