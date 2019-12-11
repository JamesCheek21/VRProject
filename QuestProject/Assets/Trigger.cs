using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    TrafficLights lights;
    public bool stopped = false;
    // Start is called before the first frame update
    void Start()
    {
        lights = GetComponentInParent<TrafficLights>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("shit");
        if (other.gameObject.tag == "car")
        {
            //Debug.Log("car");
            if (lights.state == 2)
            {
                //Debug.Log("Stop");
                //other.gameObject.GetComponent<Drive>().agent.velocity = Vector3.zero;
                other.gameObject.GetComponent<Drive>().agent.Stop();
                stopped = true;
            }
            if (lights.state == 1)
            {
                //Debug.Log("Go");
                other.gameObject.GetComponent<Drive>().agent.Resume();
                stopped = false;
            }
        }
        if(other.gameObject.tag == "person")
        {
            //Debug.Log("person");
            if(lights.state == 1)
            {
                //other.gameObject.GetComponent<Drive>().agent.velocity = Vector3.zero;
                other.gameObject.GetComponent<Patrol>().agent.Stop();
				
            }
            else if (lights.state == 2)
            {
                other.gameObject.GetComponent<Patrol>().agent.Resume();
			
			}
        }
    }
    public void OnTriggerStay(Collider other)
    {
        Debug.Log("shit");
        if (other.gameObject.tag == "car")
        {
            Debug.Log("car");
            if (lights.state == 1)
            {
                //Debug.Log("Go");
                other.gameObject.GetComponent<Drive>().agent.Resume();
                stopped = false;
            }
        }
        if (other.gameObject.tag == "person")
        {
            Debug.Log("person");
             if (lights.state == 2)
            {
                other.gameObject.GetComponent<Patrol>().agent.Resume();
            }
        }
    }
}
