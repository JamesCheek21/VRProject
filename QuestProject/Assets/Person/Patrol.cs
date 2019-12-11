using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public Transform[] points;
    //private int destPoints = 0;
    public NavMeshAgent agent;
	Animator animator;

    public bool go = false;
    public float initialDelay;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
        agent.autoBraking = false;
        int r = Random.Range(0, points.Length);
        agent.SetDestination(points[r].position);
        GoToNextPoint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!agent.pathPending && agent.remainingDistance < 0.5)
        {
            GoToNextPoint();
        }
    }
    void GoToNextPoint()
    {
        if(points.Length == 0)
            return;

        int r = Random.Range(0, points.Length);
        agent.SetDestination(points[r].position);

        //destPoints = (destPoints + 1) % points.Length;

    }
}
