using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Stop : MonoBehaviour
{
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponentInParent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "car" || other.gameObject.tag == "person")
        {
            Debug.Log("stop");
            //other.gameObject.GetComponent<Drive>().agent.velocity = Vector3.zero;
            agent.Stop();
            Debug.Log("stop2");
        }
    }
    public void OnTriggerExit(Collider other)
    {
        Debug.Log("Gay");
        if (other.gameObject.tag == "car" || other.gameObject.tag == "person")
        {
            Debug.Log("go");
            agent.Resume();
            Debug.Log("go2");

        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "car" || other.gameObject.tag == "person")
        {
            Debug.Log("stop3");
            //other.gameObject.GetComponent<Drive>().agent.velocity = Vector3.zero;
            agent.Stop();
            Debug.Log("stop4");
        }
    }
}
