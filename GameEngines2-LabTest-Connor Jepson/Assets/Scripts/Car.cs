using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float Mass = 15;
    public float MaxVelocity = 6;
    public float MaxForce = 20;

    private Vector3 velocity;

    public TrafficLights TrafficRef;

    [SerializeField]
    private Transform target;

    public List<GameObject> GreenLights;
    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateWaypoints();
        Seek();
    }

    void UpdateWaypoints()
    { 
        foreach (GameObject item in TrafficRef.gameObject.GetComponent<TrafficLights>().trafficlights)
        {
            
            var LightRef = item.gameObject.GetComponent<TrafficLightStates>();

            if (LightRef.state == TrafficLightStates.State.Green)
            {
                
                if (GreenLights.Count < 10)
                {
                    GreenLights.Add(item);
                }
            
                target = GreenLights[0].transform;

                if (Vector3.Distance(item.transform.position, this.transform.position) < 1)
                {
                    GreenLights.Remove(item);
                }
                
            }
            else if(LightRef.state == TrafficLightStates.State.Yellow || LightRef.state == TrafficLightStates.State.Red)
            {
                GreenLights.Remove(item);
            }
            
        }
    }

    void Seek()
    {
        var desiredVelocity = target.position - transform.position;
        desiredVelocity = desiredVelocity.normalized * MaxVelocity;

        var steering = desiredVelocity - velocity;
        steering = Vector3.ClampMagnitude(steering, MaxForce);
        steering /= Mass;

        velocity = Vector3.ClampMagnitude(velocity + steering, MaxVelocity);
        transform.position += velocity * Time.deltaTime;
        transform.forward = velocity.normalized;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, target.position);
    }
}
