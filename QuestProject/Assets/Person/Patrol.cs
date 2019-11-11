using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public Transform[] points;
    private int destPoints = 0;
    private NavMeshAgent agent;

    public bool go = false;
    public float initialDelay;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        GoToNextPoint();

        initialDelay = Random.Range(2.0f, 12.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!agent.pathPending && agent.remainingDistance < 0.5)
        {
            GoToNextPoint();
        }

        if(!go)
        {
            initialDelay -= Time.deltaTime;
            if (initialDelay <= 0.0f)
            {
                go = true;
                GoToNextPoint();
            }
            else return;
        }
    }
    void GoToNextPoint()
    {
          if(points.Length == 0)
            return;

        agent.destination = points[destPoints].position;

        destPoints = (destPoints + 1) % points.Length;

    }
}
