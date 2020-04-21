using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLights : MonoBehaviour
{
    public int numlights = 10;
    public float radius = 10;

    public List<GameObject> trafficlights;

  
    // Start is called before the first frame update
    void Start()
    {
        SpawnTrafficLights();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnTrafficLights()
    {
        trafficlights.Clear();
        float thetaInc = (Mathf.PI * 2) / numlights;
        for (int i = 0; i < numlights; i++)
        {
            float theta = i * thetaInc;
            Vector3 pos = new Vector3(Mathf.Sin(theta) * radius, 0, Mathf.Cos(theta) * radius);
            GameObject Cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            Cylinder.transform.position = pos;
            Cylinder.name = "TrafficLight " + (i + 1);
            trafficlights.Add(Cylinder);
            Cylinder.gameObject.AddComponent<TrafficLightStates>();
            Cylinder.transform.parent = this.transform;
        }
    }

   

    public void OnDrawGizmos()
    {
        float thetaInc = (Mathf.PI * 2) / numlights;
        for (int i = 0; i < numlights; i++)
        {
            float theta = i * thetaInc;
            Vector3 pos = new Vector3(Mathf.Sin(theta) * radius, 0, Mathf.Cos(theta) * radius);
            Gizmos.DrawWireSphere(pos,2);
        }
    }
}
