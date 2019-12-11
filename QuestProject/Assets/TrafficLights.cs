using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLights : MonoBehaviour
{
    public List<Transform> trafficlights;

    public GameObject tl1green;
    public GameObject tl1red;

    public GameObject tl2green;
    public GameObject tl2red;

    public GameObject tl3green;
    public GameObject tl3red;

    public float initialDelay = 3.0f;
    public int state = 1;

    // Start is called before the first frame update
    void Start()
    {
        trafficlights = new List<Transform>();
        GameObject[] trafficlight;
        trafficlight = GameObject.FindGameObjectsWithTag("Traffic Light");

        for(int i = 0; i <= trafficlight.Length; i++)
        {
            trafficlights.Add(trafficlight[i].transform);
        }
        LightControl();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        initialDelay -= Time.deltaTime;
        if (initialDelay < 0)
        {
            initialDelay = 10.0f;
            LightControl();
            if (state == 1)
                state++;
            else if (state == 2)
                state--;

        }
    }
    void LightControl()
    {
        if (state==1)
        {
            tl1green.active = true;
            tl1red.active = false;
            tl2green.active = false;
            tl2red.active = true;
            tl3green.active = false;
            tl3red.active = true;
        }
        else if(state==2)
        {
            tl1green.active = false;
            tl1red.active = true;
            tl2green.active = true;
            tl2red.active = false;
            tl3green.active = true;
            tl3red.active = false;
        }
    }
}
