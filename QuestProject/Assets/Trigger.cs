using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    TrafficLights lights;
    public bool stopped = false;
    public List<Drive> cars = new List<Drive>(); 
    // Start is called before the first frame update
    void Start()
    {
        lights = GetComponentInParent<TrafficLights>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lights.state == 1)
        {
            if(cars.Count != 0)
            {
                foreach(Drive d in cars)
                {
                    d.agent.Resume();
                }
                cars.Clear(); 
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "car")
        {

            //Debug.Log("car");
            if (lights.state == 2)
            {
                var vehicle = other.gameObject.GetComponent<Drive>();
                //Debug.Log("Stop");
                //other.gameObject.GetComponent<Drive>().agent.velocity = Vector3.zero;
                vehicle.agent.Stop();
                cars.Add(vehicle);
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
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "car")
        {
           // other.gameObject.GetComponent<Drive>().agent.Resume();
        }
    }
}
