using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Sphere : MonoBehaviour
{
    public GameObject currentHitObject;
    private NavMeshAgent obj;

    public Trigger stop;

    private Vector3 origin;
    private Vector3 direction;
    public float radius;
    public float maxdist;
    public LayerMask layermask;

    private float currentHitDistance;



    // Start is called before the first frame update
    void Start()
    {
        obj = GetComponent<NavMeshAgent>();
        stop = GameObject.FindGameObjectWithTag("Collision").GetComponent<Trigger>();
        //Debug.Log(stop.stopped);
    }

    // Update is called once per frame
    void Update()
    {
        
        origin = transform.position;
        direction = transform.forward;
        RaycastHit hit;
        if (Physics.SphereCast(origin, radius, direction, out hit, maxdist, layermask, QueryTriggerInteraction.UseGlobal))
        {
            currentHitObject = hit.transform.gameObject;
            currentHitDistance = hit.distance;
            //Debug.Log("stop");
            obj.velocity = Vector3.zero;
            //Debug.Log("stop2");
            obj.Stop();
            //Debug.Log("stop3");
        }
        else
        {
            currentHitDistance = maxdist;
            currentHitObject = null;
            
            //if (!stop.stopped)
            //{
            //Debug.Log("go");
            obj.Resume();
            //}
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(origin, origin + direction * currentHitDistance);
        Gizmos.DrawWireSphere(origin + direction * currentHitDistance, radius);
    }
}
