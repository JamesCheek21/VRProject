using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Drive : MonoBehaviour
{
    public Transform[] points;
    private NavMeshAgent agent;
    private int destPoints = 0;
    public Rigidbody rb;
    public Transform fwheel, bwheel;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
      
        agent.SetDestination(points[destPoints].position);
        GoToNextPoint();
        //RotateWheels();
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5)
        {
            GoToNextPoint();
            //RotateWheels();
        }
        RotateWheels();
    }

    void GoToNextPoint()
    {
        if (points.Length == 0)
            return;

        agent.SetDestination(points[destPoints].position);

        destPoints = (destPoints + 1) % points.Length;
        //RotateWheels();
    }
    void RotateWheels() 
    {
        fwheel = this.gameObject.transform.GetChild(0);
        bwheel = this.gameObject.transform.GetChild(1);
        fwheel.transform.Rotate(rb.velocity.magnitude * Time.deltaTime, 0, 0);
        bwheel.transform.Rotate(rb.velocity.magnitude * Time.deltaTime, 0, 0);
    }
}
